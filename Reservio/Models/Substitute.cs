using Reservio.Enums;

namespace Reservio.Models
{
    public class Substitute
    {
        public Guid SubstituteId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ClinicId { get;  set; }
        public WeekDay WeekDay { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }
    }
}
