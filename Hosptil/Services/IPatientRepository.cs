using Reservio.DTOS.Patient;
using Reservio.Models;

namespace Reservio.Services
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatientAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient?> GetPatientByIdASync(int patientId, bool includeReservation);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task DeletePatienyAsync(Patient patient);
        Patient MapperPatient(Patient patient, PatientCreationDTO patientCreation);
    }
}
