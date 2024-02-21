using Reservio.Core;
using Reservio.DTOS.Patient;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservio.Services.PatientRepo;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<(IEnumerable<PatientWithoutReversoinDTO>, PaginationMetaData)> GetAllPatientsAsync(PatientFilter filter);
    Task<Patient?> GetPatientByIdAsync(int patientId, bool includeRevision);
    Task<Patient> AddPatientAsync(PatientCreationDTO patient);
    Task<Patient> UpdatePatientAsync(PatientUpdateDTO patient);
    Task DeletePatientAsync(int patientId);
}