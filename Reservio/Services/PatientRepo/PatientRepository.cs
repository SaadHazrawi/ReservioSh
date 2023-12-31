using Reservio.AppDataContext;
using Reservio.DTOS.Patient;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using AutoMapper;

namespace Reservio.Services.PatientRepo
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PatientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task AddPatientAsync(ReservationForAddDto dto)
        {
            var exist = await _context.Patients.AnyAsync(p => p.IPAddress == dto.IPAddress);
            if (!exist)
            {

                var patient = _mapper.Map<Patient>(dto);
                await _context.Patients.AddAsync(patient);
            }
            await _context.SaveChangesAsync();
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

        public async Task<Patient?> GetPatientByIdASync(Guid patientId, bool includeReservation)
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
                    .FirstOrDefaultAsync(p => p.PatientId == patientId
                        && !p.IsDeleted);
        }

        //TODO Not good Code
        public Patient MapperPatient(Patient patient, PatientCreationDTO patientCreation)
        {

            patient.FirstName = patientCreation.FirstName;
            patient.LastName = patientCreation.LastName;
            patient.Gender = patientCreation.Gender;
            patient.Resgoin = patientCreation.Resgoin;
            return patient;
        }
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
    }
}
