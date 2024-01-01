using Reservio.Enums;
using Reservio.Models;
using Reservio.DTOS.Reservation;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ReservationRepo;

public interface IReservationRepository :IBaseRepository<Reservation>
{
    Task<List<Reservation>> GetAllReservationAsync();
    Task<Reservation> GetReservationByIdAsync(int reservationId); //TODO Why

    Task<ReservationStatus> CheckReservationStatus(string iPAddress);
    Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto);
    Task<Reservation> UpdateReservationAsync(Reservation reservation);

    //TODO What is Logic , Issues 1
    Task DeleteReservationAsync(Reservation reservation);
     

    Task<List<Reservation>> GetPatientsInClinic(int clinicId);
}

