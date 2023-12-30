using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationAsync();
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task<Reservation>AddReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Reservation reservation);
    }
}
