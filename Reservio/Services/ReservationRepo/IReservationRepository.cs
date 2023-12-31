using Reservio.Enums;
using Reservio.Models;
using Reservio.DTOS.Reservation;

namespace Reservio.Services.ReservationRepo;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAllReservationAsync();
    Task<Reservation> GetReservationByIdAsync(int reservationId); //TODO Why

    Task<ReservationStatus> checkReservationStatus(string iPAddress);
    Task<Reservation> AddReservationAsync(Reservation reservation);
    Task<Reservation> UpdateReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(Reservation reservation);
}

