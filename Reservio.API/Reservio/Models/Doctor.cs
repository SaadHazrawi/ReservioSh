using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Reservio.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string FullName { get; set; } = null!;

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Specialist { get; set; } = string.Empty;
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public bool IsDeleted { get; set; } = false;


    }
}
