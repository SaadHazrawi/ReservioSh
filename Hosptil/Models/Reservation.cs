namespace Hosptil.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public DateTime DateTime { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public Clinic Clinic { get; set; } = null!;
        public Patient Patient { get; set; }=null!;
    }
}
