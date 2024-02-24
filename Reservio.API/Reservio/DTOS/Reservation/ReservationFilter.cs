using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    /// <summary>
    /// Represents the input data for retrieving reservations in a clinic within a specified date range.
    /// </summary>
    public class ReservationFilter
    {
        public DateTime ReservationStart { get; set; }
        /// <summary>
        /// The end date of the reservation period.
        /// </summary>
        public DateTime ReservationEnd { get; set; }
        public int ClinicId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public GenderPatient Gender { get; set; }

        [MaxLength(100, ErrorMessage = "Region must not exceed 100 characters.")]
        public string Region { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime BookFor { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;

    }
}
