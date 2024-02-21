using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 15 characters.")]
        public string FirstName { get; set; } = null!;

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must b      e between 2 and 15 characters.")]
        public string LastName { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Region must not exceed 50 characters.")]
        public string Region { get; set; } = string.Empty;

        public GenderPatient Gender { get; set; }

        [Range(typeof(DateTime), "1/1/1823", "{0}", ErrorMessage = "Date of birth must be after 1/1/1823.")]
        public DateTime DateOfBirth { get; set; }
        //TODO Delete IPAddress
        public string IPAddress { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }


}
