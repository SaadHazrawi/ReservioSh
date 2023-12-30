using Hosptil.Enums;
using Hosptil.Models;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.DTOS.Patient
{
    public class PatientCreationDTO
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resgoin { get; set; }
        public GenderPaintet Gender { get; set; }
      
    }
}
