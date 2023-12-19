using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatientAsync(Patient patient);
         Task<Patient?> GetPatientByIdASync(int patientId, bool includeReservation);
    }
}
