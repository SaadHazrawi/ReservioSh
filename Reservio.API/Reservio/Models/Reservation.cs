using Reservio.Core;
using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.Models;
public class Reservation
{

    public int ReservationId { get; set; }
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = null!;

    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public GenderPaintet Gender { get; set; }
    [MaxLength(100, ErrorMessage = "Region must not exceed 50 characters.")]
    public string Region { get; set; } = string.Empty;
    [StringLength(100, MinimumLength = 2)]
    public string PhoneNumber { get; set; } = null!;
    public string IPAddress { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime BookFor { get; set; }
    public bool IsDeleted { get; set; } = false;

    public int ClinicId { get; set; }
  
    public Clinic Clinic { get; set; } = null!;
  
}

