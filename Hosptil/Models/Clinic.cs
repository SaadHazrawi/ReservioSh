using System.ComponentModel.DataAnnotations;

namespace Reservio.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [StringLength(maximumLength:25,MinimumLength =2)]
        public string Name { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Substitute> Substitutes { get; set; } = new List<Substitute>();
        public int CountPaitentAccepte { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
