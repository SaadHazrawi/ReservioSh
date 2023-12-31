using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Patient
{
    public class PatientWithoutReversoinDTO
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Resgoin { get; set; }
        public GenderPaintet Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
