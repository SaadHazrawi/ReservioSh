using Hosptil.AppDataContext;
using Hosptil.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            reservation.IsDeleted = true;
            _context.Update(reservation);
            await _context.SaveChangesAsync();

        }

        public Task<List<Reservation>> GetAllReservationAsync()
        {
            return _context.Reservations.ToListAsync();
        }

        public Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
