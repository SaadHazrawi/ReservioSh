using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Reservation
{
    /// <summary>
    /// Represents the input data for retrieving reservations in a clinic within a specified date range.
    /// </summary>
    public class GetReservationsByDateInput
    {
        /// <summary>
        /// The ID of the clinic.
        /// </summary>
        public int ClinicId { get; set; }

        /// <summary>
        /// The start date of the reservation period.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the reservation period.
        /// </summary>
        public DateTime EndDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;

    }
}
