using Reservio.Enums;

namespace Reservio.Models
{
    public class Substitute
    {
        public int SubstituteId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get;  set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }
    }
}
