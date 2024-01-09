using Reservio.Enums;
using Reservio.Models;
using Reservio.DTOS.Reservation;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ReservationRepo;

public interface IReservationRepository :IBaseRepository<Reservation>
{
    Task<List<Reservation>> GetAllReservationAsync();

    Task<ReservationStatus> CheckReservationStatus(string iPAddress);
    Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto);
    Task<Reservation> UpdateReservationAsync(int reservationId,ReservationUpdateDTO reservationDto);

    //TODO What is Logic , Issues 1
    Task DeleteReservationAsync(Reservation reservation);
     




}

