using Reservio.Models;

namespace Reservio.DTOS.Schedule
{
    public class ScheduleResponse
    {
        public List<DoctorForShcudleDto> Doctors { get; set; } = null!;
        public List<ClinicForShcudleDto> Clinics { get; set; } = null!;
        public List<ScheduleDto> Schedules { get; set; } = null!;
    }

    public class DoctorForShcudleDto
    {
        public int Value { get; set; }
        public string Title { get; set; } = null!;
    }
    public class ClinicForShcudleDto
    {
        public int Value { get; set; }
        public string Title { get; set; } = null!;
    }



}