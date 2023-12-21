using Hosptil.DTOS.Clinic;
using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IClinicRepository
    {
        Task<List<Clinic?>> GetAllCinicsAsync();
        Task<Clinic> AddClinicAsync(Clinic clinic);
        Task<Clinic?> GetClinicByIdAsync(int clinicId);
        Task<Clinic> UpdateClinicAsync(Clinic clinic);
        Task DeleteClinicAsync(Clinic clinic);
    }
}
