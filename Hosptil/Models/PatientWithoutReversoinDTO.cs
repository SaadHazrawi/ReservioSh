using Hosptil.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.Models
{
    public class PatientWithoutReversoinDTO
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resgoin { get; set; }
        public GenderPaintet Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
