using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.PatientRepo
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetPatientByIdAsync(int patientId, bool includeRevision);
        Task<Patient> AddPatientAsync(PatientCreationDTO patient);
        Task<Patient> UpdatePatientAsync(PatientUpdateDTO patient);
        Task DeletePatienyAsync(Patient patient);
      
    }
}
