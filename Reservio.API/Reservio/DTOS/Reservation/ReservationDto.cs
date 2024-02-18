using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public GenderPaintet Gender { get; set; }
        public string Region { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime BookFor { get; set; }
        public string Clinic { get; set; }
    }
}
