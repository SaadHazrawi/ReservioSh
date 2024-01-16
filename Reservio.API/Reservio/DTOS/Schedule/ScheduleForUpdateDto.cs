namespace Reservio.DTOS.Schedule
{
    public class ScheduleForUpdateDto
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public DayOfWeek Day { get; set; }
    }




}