﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.Clinic;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Net;

namespace Reservio.Services.ClinicRepo
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitOfWork> _logger;

        public ClinicRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<Clinic>> GetAllCinicsAsync()
        {
            List<Clinic> clinics = await _context.Clinics.Where(c => !c.IsDeleted).ToListAsync();
            if (clinics is null)
            {
                _logger.LogError("He asked all the clinics and found nothing");
                throw new APIException(HttpStatusCode.NotFound, "Not Found Any Clinics in your system");
            }
            return clinics;
        }
        public async Task<Clinic> AddClinicAsync(ClinicCreationDTO clinic)
        {
            if (clinic is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Add Empty or null Clinic please try again with corriect data ....");
            }
            var clinicCreate = _mapper.Map<Clinic>(clinic);
            await _context.Clinics.AddAsync(clinicCreate);
            await _context.SaveChangesAsync();
            return clinicCreate;
        }


        public async Task<Clinic?> GetClinicByIdAsync(int clinicId)
        {

            Clinic? clinic = await _context.Clinics
                                .FirstOrDefaultAsync(c => c.ClinicId == clinicId
                                && c.IsDeleted == false);
            if (clinic is null)
                throw new APIException(HttpStatusCode.NotFound, "Not found Clinic");
            return clinic;
        }

        public async Task<Clinic> UpdateClinicAsync(int clinicId, ClinicForUpdateDTO clinic)
        {
            Clinic clinicToUpdate = await GetByIdAsync(clinicId);
            if (clinicToUpdate is null)
            {
                _logger.LogError($"Error Has Been Becuase the Clinic With Id : {clinicId} Not Fiund in system");
                throw new APIException(HttpStatusCode.NotFound);
            }
            if (clinic is null)
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Edit Empty or null Clinic please try again with corriect data ....");
            _mapper.Map(clinic, clinicToUpdate);
            _context.Update(clinicToUpdate);
            await _context.SaveChangesAsync();
            return clinicToUpdate;
        }

        public async Task DeleteClinicAsync(int clinicId)
        {
            Clinic clinic = await GetByIdAsync(clinicId);
            if (clinic is null)
            {
                _logger.LogError($"Clinic not found with ID: {clinicId}");
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Delete Clinic .... try Agein");
            }
            clinic.IsDeleted = true;
            bool isClinicScheduled = await _context.Schedules
                                        .AnyAsync(s => s.ClinicId == clinicId);
            if (isClinicScheduled)
            {
                var schedules = await _context.Schedules
                                    .Where(s => s.ClinicId == clinicId)
                                    .ToListAsync();
                schedules.ForEach(schedule => schedule.IsDeleted = true);
                _context.Schedules.UpdateRange(schedules);
            }
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task<Clinic> ReActivateClinicAsync(int clincicId)
        {
            Clinic? unActiveClinic = await _context.Clinics
                .FirstOrDefaultAsync(c => c.ClinicId == clincicId && c.IsDeleted);
            if (unActiveClinic is null)
            {
                throw new APIException(HttpStatusCode.NotFound, "This Clinic Is not Found or not Delete From System");
            }
            unActiveClinic.IsDeleted = false;
            _context.Clinics.Update(unActiveClinic);
            await _context.SaveChangesAsync();
            return unActiveClinic;
        }



        public async Task<List<ClinicDto>> GetClinicsForReservations()
        {
            DateTime today = ReservationHelper.DetermineBookingDateTime();
            DayOfWeek currentDayOfWeek = today.DayOfWeek;
            var (startOfWeek, endOfWeek) = ReservationHelper.GetStartAndEndOfWeek(today);

            var schedules = await _context.Schedules
                .Include(s => s.Clinic)
                .Where(s => s.Day == currentDayOfWeek &&
                            s.Clinic.AcceptedPatientsCount > s.Clinic.Reservations.Count)
                .ToListAsync();

            var doctorIdsOnVacation = await _context.Vacations
                .Where(v => v.DateTime >= startOfWeek && v.DateTime <= endOfWeek)
                .Select(v => v.DoctorId)
                .ToListAsync();

            var availableClinics = schedules
                .Where(s => !doctorIdsOnVacation.Contains(s.DoctorId))
                .Select(s => s.Clinic)
                .ToList();

            var clinicDtos = _mapper.Map<List<ClinicDto>>(availableClinics);
            return clinicDtos;
        }


        public async Task<List<ClinicStatisticDto>> GetClinicsStatisticsAsync()
        {
            var clinicsWithReservationCounts = await _context.Clinics
                .Where(c=>c.IsDeleted==false)
                .Include(c=>c.Reservations)
                .ToListAsync();
            
            var dto = _mapper.Map<List<ClinicStatisticDto>>(clinicsWithReservationCounts);
            if (clinicsWithReservationCounts is null)
            {
                throw new APIException(HttpStatusCode.NotFound, "No statistics were found. Try again later");
            }
            return dto;
        }
    }
}
