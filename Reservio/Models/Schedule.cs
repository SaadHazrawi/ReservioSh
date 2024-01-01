using Reservio.Enums;

namespace Reservio.Models
{
    public class Schedule
    {
        //TODO Rename ScheduleId
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get;  set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Clinic Clinic { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}
