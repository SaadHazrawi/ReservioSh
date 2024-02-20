using Reservio.Enums;

namespace Reservio.DTOS.Patient
{
    public class PatientWithoutReversoinDTO
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Regoin { get; set; }
        public GenderPatient Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
