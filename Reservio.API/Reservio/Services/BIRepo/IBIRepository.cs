using Reservio.DTOS.BI;
using Reservio.DTOS.Reservation;
using Reservio.Models;

namespace Reservio.Services.BIRepo
{
    public interface IBIRepository
    {
       Task<List<ValueName>> GetCountByGenderPatient();
       Task<List<int>> GetPatientInWeek();
    }
}
