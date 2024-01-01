using System.ComponentModel.DataAnnotations;

namespace Reservio.Models;
public class Reservation
{
    public int ReservationId { get; set; }
    public int ClinicId { get; set; }
    public string IPAddress { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime BookFor { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Clinic Clinic { get; set; } = null!;
}

