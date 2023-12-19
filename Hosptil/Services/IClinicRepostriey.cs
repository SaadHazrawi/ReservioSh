using Hosptil.DTOS.Clinic;
using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IClinicRepository
    {
        Task<Clinic> AddClinicAsync(Clinic clinic);
        Task<Clinic?> GetClinicByIdAsync(int clinicId);
    }
}
