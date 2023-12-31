namespace Reservio.DTOS.Reservation;
public class ReservationStatus
{
    public string Status { get; set; } = string.Empty;
    public string stoppingTo { get; set; } = string.Empty;
    public bool stopping { get; set; } = false;
}
