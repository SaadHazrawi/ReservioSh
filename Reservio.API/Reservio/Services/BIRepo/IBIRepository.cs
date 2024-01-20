using Reservio.DTOS.BI;
using Reservio.DTOS.Clinic;
using Reservio.Models;

namespace Reservio.Services.BIRepo
{
    public interface IBIRepository
    {
        Task<List<ValueName>> GetCountByGenderPatient();
        Task<List<int>> GetPatientInWeek();
        Task<PatientInClinicDto> GetPatientInClinic();
    }
}
