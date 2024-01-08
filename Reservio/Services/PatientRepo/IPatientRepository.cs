using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.PatientRepo
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<List<Patient>> GetAllPatientAsync();

        Task<List<Reservation>> GetPatientsInClinic(int clinicId);

        Task<Patient> AddPatientAsync(Patient patient);

        Task<Patient?> GetPatientByIdASync(int patientId, bool includeReservation);
        Task<Patient> UpdatePatientAsync(PatientCreationDTO patient);
        Task DeletePatienyAsync(Patient patient);
      
    }
}
