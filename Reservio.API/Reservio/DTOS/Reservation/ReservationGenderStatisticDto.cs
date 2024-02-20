using Reservio.Enums;

namespace Reservio.DTOS.Reservation
{
    public class ReservationGenderStatisticDto
    {
        public GenderPatient Gender { get; set; }
        public int Count { get; set; }
    }
}
