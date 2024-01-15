using Reservio.DTOS.Clinic;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ClinicRepo
{
    public interface IClinicRepository : IBaseRepository<Clinic>
    {
        Task<List<Clinic>> GetAllCinicsAsync();
        Task<List<ClinicStatisticDto>> GetClinicsStatisticsAsync();
        Task<Clinic> AddClinicAsync(ClinicCreationDTO clinic);
        Task<Clinic?> GetClinicByIdAsync(int clinicId);
        Task<Clinic> UpdateClinicAsync(int clinicId, ClinicForUpdateDTO clinic);
        Task DeleteClinicAsync(int clinicId);
        Task<Clinic> ReActivateClinicAsync(int clincicId);
        Task<List<ClinicDto>> GetClinicsForReservations();
    }
}
