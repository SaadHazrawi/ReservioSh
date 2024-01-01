using Reservio.DTOS.Clinic;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ClinicRepo
{
    public interface IClinicRepository :IBaseRepository<Clinic>
    {
        Task<List<Clinic?>> GetAllCinicsAsync();
        Task<Clinic> AddClinicAsync(Clinic clinic);
        Task<Clinic?> GetClinicByIdAsync(int clinicId);
        Task<Clinic> UpdateClinicAsync(Clinic clinic);
        Task DeleteClinicAsync(Clinic clinic);
    }
}
