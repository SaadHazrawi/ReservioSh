using Reservio.Enums;

namespace Reservio.DTOS.Reservation;
public class ReservationStatus
{
    public Enums.ReservationState Status { get; set; } 
    public string StoppingTo { get; set; } = string.Empty;
}
