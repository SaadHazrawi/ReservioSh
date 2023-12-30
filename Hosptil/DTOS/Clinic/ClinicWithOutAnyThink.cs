using Hosptil.Models;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.DTOS.Clinic
{
    public class ClinicCreationDTO
    {
        public string Name { get; set; }
        public int CountPaitentAccepte { get; set; }

    }
}
