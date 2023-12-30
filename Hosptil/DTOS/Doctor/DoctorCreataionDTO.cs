using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Doctor
{
    public class DoctorCreataionDTO
    {
        public string FullName { get; set; }
        public string Specialist { get; set; }
    }
}
