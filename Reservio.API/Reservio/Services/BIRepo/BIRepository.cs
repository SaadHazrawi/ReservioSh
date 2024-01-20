using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.BI;
using Reservio.DTOS.Clinic;
using Reservio.DTOS.Reservation;
using Reservio.Enums;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System;
using System.Reflection.Metadata;

namespace Reservio.Services.BIRepo
{
    public class BIRepository:IBIRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        private ILogger<UnitOfWork> _logger;

        public BIRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ValueName>> GetCountByGenderPatient()
        {
            var patientsByGender = await _context.Reservations
                    .GroupBy(r => r.Gender)
                     .Select(g => new ValueName
                     {
                         Name = g.Key.ToString(),
                         Value = g.Count()
                     }).ToListAsync();

            return patientsByGender;
        }

        public async Task<List<int>> GetPatientInWeek()
        {
            DateTime startOfWeek = ReservationHelper.GetStartOfWeek();
            var reservations = await _context.Reservations
                .Where(r => r.BookFor > startOfWeek)
                .GroupBy(r => r.BookFor)
                .Select(r => new ValueDateTime
                {
                    DateTime = r.Key,
                    Value = r.Count()
                })
                .ToListAsync();

            int[] patientCount = new int[7];
            foreach (var reservation in reservations)
            {
                int index = (int)reservation.DateTime.DayOfWeek;
                patientCount[index] = reservation.Value;
            }

            return patientCount.ToList();
        }

        public async Task<PatientInClinicDto> GetPatientInClinic()
        {


            var clinicsWithReservationCounts = await _context.Clinics
                                         .Where(c => !c.IsDeleted)
                                         .Select(c => new
                                         {
                                             ClinicName = c.Name,
                                             CountPatient = c.Reservations.Count(r => !r.IsDeleted)
                                         })
                                         .ToListAsync();

            var clinicNames = clinicsWithReservationCounts.Select(c => c.ClinicName).ToArray();
            var countPatients = clinicsWithReservationCounts.Select(c => c.CountPatient).ToArray();
            string[] randomColorArray = ReservationHelper.GetRandomColors(clinicNames.Length);
            var patientInClinicDto = new PatientInClinicDto { ClinicNames = clinicNames, CountPatients = countPatients, RandomColor = randomColorArray };
            return patientInClinicDto;
        }


        public async Task<DataObject> GetPatientInClinicInDataAsync(TimePeriod period)
        {
            string formatDate = string.Empty;
            if ((int)period == 2 )
            {
                formatDate = "mm";
            }

            var clinicsWithReservationCounts = await _context.Reservations
                .Where(r=>r.BookFor.Year>DateTime.Now.Year)
                .Select(r => r.BookFor.ToString(formatDate))
                .Distinct()
                .ToListAsync();

            //var clinicNames = clinicsWithReservationCounts.Select(c => c.ClinicName).ToArray();
            //var countPatients = clinicsWithReservationCounts.Select(c => c.CountPatient).ToArray();
            //string[] randomColorArray = ReservationHelper.GetRandomColors(clinicNames.Length);
            //var patientInClinicDto = new PatientInClinicDto { ClinicNames = clinicNames, CountPatients = countPatients, RandomColor = randomColorArray };
            //return patientInClinicDto;
        }

    }
}
