namespace Hosptil.DTOS.Clinic
{
    public class ClinicWithiutAnyThinkAsync
    {

        public int ClinicId { get; set; }
        public string Name { get; set; }
        public int CountPaitentAccepte { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
