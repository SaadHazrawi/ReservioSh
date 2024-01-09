namespace Reservio.DTOS.Clinic
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public int CountPaitentAccepted { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
