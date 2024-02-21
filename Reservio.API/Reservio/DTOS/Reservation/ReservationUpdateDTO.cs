using Reservio.Core;
using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    public class ReservationUpdateDTO
    {
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Date of birth must be between 1/1/1900 and the current date.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public GenderPatient Gender { get; set; }

        [MaxLength(100, ErrorMessage = "Region must not exceed 100 characters.")]
        public string Region { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(\+|00)[0-9]{2,18}$", ErrorMessage = "Phone number must start with '00' or '+' and have a length between 6 and 20 digits.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Booking date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime BookFor { get; set; }


        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")]
        public string IPAddress { get; set; } = null!;
    }
}
