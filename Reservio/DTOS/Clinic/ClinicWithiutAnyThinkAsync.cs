namespace Reservio.DTOS.Clinic
{
    public class ClinicWithiutAnyThinkAsync
    {

        public Guid ClinicId { get; set; }
        public string Name { get; set; }
        public int CountPaitentAccepte { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
