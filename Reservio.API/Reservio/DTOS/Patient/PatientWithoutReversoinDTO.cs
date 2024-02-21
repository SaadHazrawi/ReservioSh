using Reservio.Enums;

namespace Reservio.DTOS.Patient
{
    public class PatientWithoutReversoinDTO
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Region { get; set; } = string.Empty;

        public GenderPatient Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
 
}
