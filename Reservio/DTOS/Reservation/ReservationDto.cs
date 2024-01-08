using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public GenderPaintet Gender { get; set; }
        public string Resgoin { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 2)]
        public string PhoneNumber { get; set; } = null!;
        public string IPAddress { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime BookFor { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int ClinicId { get; set; }
    }
}
