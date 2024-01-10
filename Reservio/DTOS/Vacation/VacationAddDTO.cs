namespace Reservio.DTOS.Vacation
{
    public class VacationAddDTO
    {
        public int DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime DateTime { get; set; }
    }
}
