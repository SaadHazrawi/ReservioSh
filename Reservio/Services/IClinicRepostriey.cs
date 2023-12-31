using Reservio.DTOS.Clinic;
using Reservio.Models;

namespace Reservio.Services
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
