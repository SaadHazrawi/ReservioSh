using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.BI;
using Reservio.DTOS.Clinic;
using Reservio.DTOS.Reservation;
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
            Random random = new Random();
            
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
            var randomColorArray = new string[clinicNames.Length];
            for (int i = 0; i < randomColorArray.Length; i++)
            {
                string randomColor = String.Format("#{0:X6}", random.Next(0x1000000));
                randomColorArray[i] = randomColor;



            }
            var patientInClinicDto = new PatientInClinicDto { ClinicNames = clinicNames, CountPatients = countPatients,RandomColor= randomColorArray };
            
        
           
            return patientInClinicDto;
        }


    }
}
