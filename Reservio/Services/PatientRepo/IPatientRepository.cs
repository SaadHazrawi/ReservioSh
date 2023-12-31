using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.Models;

namespace Reservio.Services.PatientRepo
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatientAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task AddPatientAsync(ReservationForAddDto dto);
        Task<Patient?> GetPatientByIdASync(Guid patientId, bool includeReservation);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task DeletePatienyAsync(Patient patient);
        Patient MapperPatient(Patient patient, PatientCreationDTO patientCreation);
    }
}
