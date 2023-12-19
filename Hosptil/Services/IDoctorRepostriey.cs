using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IDoctorRepostriey
    {
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
    }
}
