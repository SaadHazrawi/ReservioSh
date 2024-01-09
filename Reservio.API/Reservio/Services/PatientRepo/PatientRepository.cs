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
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task GetPatientIdForReservationAsync(ReservationForAddDto dto)
        {
           throw new NotImplementedException();
        }

        public async Task DeletePatienyAsync(Patient patient)
        {
            patient.IsDeleted = true;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Patient>> GetAllPatientAsync()
        {
            return await _context.Patients
                        .Where(p => !p.IsDeleted)
                          .ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdASync(int patientId, bool includeReservation)
        {
            if (includeReservation)
            {
                return await _context.Patients
                .Include(r => r.Reservations)
                  .FirstOrDefaultAsync(p => p.PatientId == patientId
                  && !p.IsDeleted);
            }

            else
                return await _context.Patients
                    .FirstOrDefaultAsync(p => p.PatientId == patientId && !p.IsDeleted);
        }



        public async Task<List<Reservation>> GetPatientsInClinic(int clinicId)
        {
            return await _context.Reservations
                .Where(c => c.ClinicId == clinicId
                && c.BookFor.Date == DateTimeLocal.GetDate())
               .ToListAsync();

        }

        public async Task<Patient> UpdatePatientAsync(int patientId ,  PatientCreationDTO dto)
        {

            if (dto is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Adding failed.");
            }

            var patient = await GetPatientByIdASync(patientId, false);
            if (patient is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Adding failed. The Doctor does not exist..");
            }
            _mapper.Map(dto, patient);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        //TODO For Abdullah
        public Task<Patient> UpdatePatientAsync(PatientCreationDTO patient)
        {
            throw new NotImplementedException();
        }
    }
}
