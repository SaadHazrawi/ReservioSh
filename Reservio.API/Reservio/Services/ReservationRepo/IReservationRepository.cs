using Reservio.Enums;
using Reservio.Models;
using Reservio.DTOS.Reservation;
using Reservio.Services.BaseRepo;
using Reservio.Core;

namespace Reservio.Services.ReservationRepo;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<(IEnumerable<ReservationDto>, PaginationMetaData)> GetReservationsByDateAsync(GetReservationsByDateInput dto);
    Task<ReservationStatus> CheckReservationStatusByIPAddress(string ipAddress);
    Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto);
    Task<Reservation> UpdateReservationAsync(int reservationId, ReservationUpdateDTO reservationDto);
    Task MarkReservationAsPatientVisitReviewedAsync(int id);
}

