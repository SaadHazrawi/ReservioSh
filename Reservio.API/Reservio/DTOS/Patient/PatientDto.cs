using Reservio.Enums;

namespace Reservio.DTOS.Patient
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Region { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
    }
 
}
