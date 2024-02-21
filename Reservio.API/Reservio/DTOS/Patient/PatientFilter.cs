using Reservio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Reservio.DTOS.Patient
{
    public class PatientFilter
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Region { get; set; } = string.Empty;

        public GenderPatient Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }

}
