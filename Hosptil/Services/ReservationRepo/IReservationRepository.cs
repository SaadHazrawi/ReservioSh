using Hosptil.Enums;
using Hosptil.Models;
using Hosptil.DTOS.Reservation;

namespace Hosptil.Services.ReservationRepo;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAllReservationAsync();
    Task<Reservation> GetReservationByIdAsync(int reservationId); //TODO Why

    Task<ReservationStatus> checkReservationStatus(string iPAddress);
    Task<Reservation> AddReservationAsync(Reservation reservation);
    Task<Reservation> UpdateReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(Reservation reservation);
}

