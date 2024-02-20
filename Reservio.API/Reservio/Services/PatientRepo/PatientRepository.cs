using Reservio.AppDataContext;
using Reservio.DTOS.Patient;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using AutoMapper;
using Reservio.Services.BaseRepo;
using Reservio.Core;
using System.Net;
using System.Numerics;

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
        public async Task<Patient> AddPatientAsync(PatientCreationDTO dto)
        {

            var patient =_mapper.Map<Patient>(dto);
            if (patient == null)
            {
                throw new APIException(HttpStatusCode.NotFound, "Adding failed.");

            }

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;


        }


        public async Task DeletePatienyAsync(Patient patient)
        {
            patient.IsDeleted = true;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients
                        .Where(p => !p.IsDeleted)
                          .ToListAsync();
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


    


        public async Task<Patient> UpdatePatientAsync(PatientUpdateDTO dto)
        {
            if (dto is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Update failed. Invalid data provided.");
            }

            var patient = await GetPatientByIdAsync(dto.Id, false);
            if (patient is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Update failed. The patient does not exist.");
            }

            _mapper.Map(dto, patient);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
