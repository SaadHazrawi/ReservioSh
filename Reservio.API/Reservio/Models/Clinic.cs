using System.ComponentModel.DataAnnotations;

namespace Reservio.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        [StringLength(maximumLength:50,MinimumLength =2)]
        public string Name { get; set; } = string.Empty;
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public int CountPaitentAccepted { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
