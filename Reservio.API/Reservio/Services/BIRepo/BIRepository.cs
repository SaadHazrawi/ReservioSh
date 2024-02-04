using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.BI;
using Reservio.DTOS.Clinic;
using Reservio.Enums;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.BIRepo
{
    public class BIRepository : IBIRepository
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

        public async Task<DataObject> GetPatientCountInClinicsAsync(TimePeriod period)
        {
            string formatDate = string.Empty;
            if (period == TimePeriod.Month)
            {
                formatDate = "MM";
            }


            var reservationsInSelectedYear = await _context.Reservations
                .Where(r => r.BookFor.Year == DateTime.Now.Year).ToListAsync();

            var labels = reservationsInSelectedYear
                .GroupBy(r => r.BookFor.ToString(formatDate))
                .Select(g => new
                {
                    Date = g.Key,
                })
                .ToList();

            var datasets = new List<Dataset>();
            var clinicIds = await _context.Clinics.Select(c => c.ClinicId).Distinct().ToListAsync();
            foreach (var clinicId in clinicIds)
            {
                var dataset = new Dataset();
                dataset.Label = _context.Clinics.FirstOrDefault(c => c.ClinicId == clinicId)!.Name;
                dataset.Data = new List<int>();
                dataset.BackgroundColor = ReservationHelper.GetRandomColors(1)[0];

                foreach (var date in labels)
                {
                    var month = Convert.ToInt32(date.Date);

                    var count = await _context.Reservations
                        .Where(x => x.ClinicId == clinicId && x.BookFor.Month == month && x.BookFor.Year == DateTime.Now.Year)
                        .CountAsync();

                    dataset.Data.Add(count);
                }

                datasets.Add(dataset);
            }

            var data = new DataObject();
            data.Labels = labels.Select(c => c.Date).ToList();
            data.Datasets = datasets;

            return data;
        }

    }