using Hosptil.DTOS.Patient;
using Hosptil.Models;

namespace Hosptil.Services
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
