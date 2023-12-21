using Hosptil.AppDataContext;
using Hosptil.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
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
                    .FirstOrDefaultAsync(p => p.PatientId == patientId
                        && !p.IsDeleted);
        }

    }
}
