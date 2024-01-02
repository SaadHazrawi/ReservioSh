using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.Services.BaseRepo;
using AutoMapper;
using Reservio.Core;

namespace Reservio.Services.ClinicRepo
{
    public class ClinicRepository :BaseRepository<Clinic>, IClinicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClinicRepository(DataContext context ,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
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



        public async Task<List<Clinic>> GetClinicsForReservations()
        {

            return await _context.Schedules
                 .Where(p => p.DayOfWeek == ReservationHelper.DetermineBookingDayOfWeek()
                  && p.Clinic.CountPaitentAccepte > p.Clinic.Reservations.Count)
                 .Select(p => p.Clinic)
                 .ToListAsync();
        }
    }
}
