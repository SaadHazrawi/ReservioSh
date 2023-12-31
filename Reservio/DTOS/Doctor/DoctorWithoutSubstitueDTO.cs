using Reservio.Models;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Doctor
{
    public class DoctorWithoutSubstitueDTO
    {
        public Guid DoctorId { get; set; }
        public string FullName { get; set; }
        public string Specialist { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
