using Reservio.Enums;
using Reservio.Models;
using Reservio.DTOS.Reservation;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ReservationRepo;

public interface IReservationRepository :IBaseRepository<Reservation>
{
    Task<List<Reservation>> GetAllReservationAsync();
    //TODO saad=>It's an old thing. After sitting with you, we agreed to delete it
    Task<Reservation> GetReservationByIdAsync(int reservationId); //TODO To Saad: Why

    Task<ReservationStatus> CheckReservationStatus(string iPAddress);
    Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto);
    Task<Reservation> UpdateReservationAsync(int reservationId,ReservationUpdateDTO reservationDto);

    //TODO What is Logic , Issues 1
    Task DeleteReservationAsync(Reservation reservation);
     




}

