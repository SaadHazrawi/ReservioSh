using Hosptil.AppDataContext;
using Hosptil.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Services
{
    public class DoctorRepostriey : IDoctorRepostriey
    {
        private readonly DataContext _context;

        public DoctorRepostriey(DataContext context)
        {
            this._context = context;
        }
        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
           await _context.SaveChangesAsync();
            return doctor;
        }

        public Task<Doctor> GetDoctorByIdAsync(int doctorId,bool includeSubstite)
        {
            if (!includeSubstite)
            {
                return _context.Doctors
                        .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                        && d.IsDeleted == false);
            }
            else
            {
                return _context.Doctors
                    .Include(d=>d.Substitutes)
                      .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                      && d.IsDeleted == false);
            }
        }
    }
}
