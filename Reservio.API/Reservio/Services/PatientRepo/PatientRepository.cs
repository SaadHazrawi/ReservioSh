using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservio.AppDataContext;
using Reservio.DTOS.Patient;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using Reservio.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Reservio.DTOS.Reservation;
using Reservio.Enums;

namespace Reservio.Services.PatientRepo
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitOfWork> _logger;

        public PatientRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<(IEnumerable<PatientDto>, PaginationMetaData)> GetAllPatientsAsync(PatientFilter filter)
        {
            var query = _context.Patients
                .Where(p => !p.IsDeleted);

            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(p => p.LastName.Contains(filter.LastName));
            }

            if (!string.IsNullOrEmpty(filter.Region))
            {
                query = query.Where(p => p.Region.Contains(filter.Region));
            }

            if (filter.Gender != GenderPatient.Unknown)
            {
                query = query.Where(p => p.Gender == filter.Gender);
            }

            if (filter.DateOfBirth != default)
            {
                query = query.Where(p => p.DateOfBirth == filter.DateOfBirth);
            }

            var totalPatients = await query.CountAsync();

            var patients = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();


            var patientsDto = _mapper.Map<IReadOnlyList<PatientDto>>(patients);
            var paginationMetaData = new PaginationMetaData(totalPatients, filter.PageSize, filter.PageNumber);

            return (patientsDto, paginationMetaData);
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId, bool includeRevision)
        {
            var query = _context.Patients as IQueryable<Patient>;

            if (includeRevision)
            {
                query = query.Include(r => r.Reservations);
            }

            var patient = await query.FirstOrDefaultAsync(p => p.PatientId == patientId && !p.IsDeleted);

            if (patient is null)
            {
                throw new APIException(HttpStatusCode.NotFound, "Patient not found.");
            }

            return patient;
        }
        
        public async Task<Patient> AddPatientAsync(PatientCreationDTO dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            if (patient == null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Adding failed.");
            }

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
       
        public async Task<Patient> UpdatePatientAsync(PatientUpdateDTO dto)
        {
            if (dto is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Update failed. Invalid data provided.");
            }

            var patient = await GetPatientByIdAsync(dto.PatientId, false);

            if (patient is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Update failed. The patient does not exist.");
            }

            _mapper.Map(dto, patient);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task DeletePatientAsync(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Delete failed. The patient does not exist.");
            }

            patient.IsDeleted = true;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

    }
}