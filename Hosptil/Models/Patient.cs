using Hosptil.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 15 characters.")]
        public string FirstName { get; set; } = null!;

        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 15 characters.")]
        public string LastName { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "Resgoin must not exceed 50 characters.")]
        public string Resgoin { get; set; } = string.Empty;

        public GenderPaintet Gender { get; set; }

        [Range(typeof(DateTime), "1/1/1823", "{0}", ErrorMessage = "Date of birth must be after 1/1/1823.")]
        public DateTime dateOfBirth { get; set; }

        public string IPAddress { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
