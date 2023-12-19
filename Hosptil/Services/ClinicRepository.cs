using Hosptil.AppDataContext;
using Hosptil.DTOS.Clinic;
using Hosptil.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Services
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly DataContext _context;

        public ClinicRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Clinic> AddClinicAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();  
            return clinic;
        }

        public async Task<Clinic?> GetClinicByIdAsync(int clinicId)
        {
             
            return await _context.Clinics
                                .FirstOrDefaultAsync(c => c.ClinicId == clinicId 
                                && c.IsDeleted == false);
        }
    }
}
