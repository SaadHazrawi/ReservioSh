namespace Reservio.DTOS.Clinic
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public int AcceptedPatientsCount { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
