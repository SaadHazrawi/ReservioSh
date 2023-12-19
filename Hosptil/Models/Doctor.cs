using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hosptil.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Specialist { get; set; }
        public List<Substitute> Substitutes { get; set; } = new List<Substitute>();
        public bool IsDeleted { get; set; } = false;


    }
}
