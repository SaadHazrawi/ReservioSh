using Hosptil.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hosptil.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [StringLength(maximumLength:15,MinimumLength =2)]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Resgoin { get; set; }
        public GenderPaintet Gender { get; set; }
        public List<Reservation> Reservations { get; set; }=new List<Reservation>();
        public bool IsDeleted { get; set; } = false;



    }
}
