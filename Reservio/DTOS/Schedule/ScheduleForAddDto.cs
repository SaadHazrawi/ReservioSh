namespace Reservio.DTOS.Schedule
{
    public class ScheduleForAddDto
    {
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

    
}