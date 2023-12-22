using Hosptil.DTOS.Doctor;
using Hosptil.Models;

namespace Hosptil.Services
{
    public interface IDoctorRepostriey
    {
        Task<List<Doctor?>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor doctor);
      Doctor  MapperDoctorForUpdate(Doctor doctor, DoctorCreataionDTO updateDto);
    }
}
