namespace Reservio.DTOS.Clinic
{
    public class ClinicStatisticDto
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public int ReservationCount { get; set; }
    }
}
