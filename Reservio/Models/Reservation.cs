using System.ComponentModel.DataAnnotations;

namespace Reservio.Models;
public class Reservation
{
    public Guid ReservationId { get; set; }
    public Guid PatientId { get; set; }
    public Guid ClinicId { get; set; }
    public string IPAddress { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime BookFor { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Clinic Clinic { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}

