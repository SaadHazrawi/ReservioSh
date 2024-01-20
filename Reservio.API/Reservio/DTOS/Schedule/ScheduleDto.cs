namespace Reservio.DTOS.Schedule
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string Doctor { get; set; } = null!;
        public string Clinic { get; set; } = null!;
        public string Day { get; set; } = null!;
    }

    
}