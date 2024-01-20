namespace Reservio.Models
{
    public class Vacation
    {
        public int VacationId { get; set; }
        public DayOfWeek Day { get; set; }
        public int DoctorId { get; set; }
        //ADD Date For
        public DateTime DateTime { get; set; }
    }
}
