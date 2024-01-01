using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ClinicRepo
{
    public class ClinicRepository :BaseRepository<Clinic>, IClinicRepository
    {
        private readonly DataContext _context;

        public ClinicRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Clinic?>> GetAllCinicsAsync()
        {
            return await _context.Clinics.Where(c => !c.IsDeleted).ToListAsync();
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

        public async Task<Clinic> UpdateClinicAsync(Clinic clinic)
        {
            _context.Update(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }

        public async Task DeleteClinicAsync(Clinic clinic)
        {
            clinic.IsDeleted = true;
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }
    }
}
