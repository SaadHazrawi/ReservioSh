namespace Reservio.DTOS.Schedule
{
    public class ScheduleDto
    {
        public string Doctor { get; set; } = null!;
        public string Clinic { get; set; } = null!;
        public string Day { get; set; } = null!;
    }
    public class ScheduleForEditDto
    {
        public DoctorForShcudluDto Doctor { get; set; } = null!;
        public ClinicForShcudluDto Clinic { get; set; } = null!;
        public string Day { get; set; } = null!;
    }
    public class DoctorForShcudluDto
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; } = null!;
    }
    public class ClinicForShcudluDto
    {
        public int ClinicId { get; set; }
        public string Name { get; set; } = null!;
    }
    
}