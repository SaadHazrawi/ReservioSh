using Reservio.Enums;
using Reservio.Models;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Patient
{
    public class PatientCreationDTO
    {

        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 15 characters.")]
        public string FirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 15 characters.")]
        public string LastName { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "Region must not exceed 50 characters.")]
        public string Region { get; set; } = string.Empty;
        public GenderPaintet Gender { get; set; }
      
    }
}
