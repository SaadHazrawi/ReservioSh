using Reservio.Enums;
using Reservio.Models;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Patient
{
    public class PatientCreationDTO
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Resgoin { get; set; }
        public GenderPaintet Gender { get; set; }
      
    }
}
