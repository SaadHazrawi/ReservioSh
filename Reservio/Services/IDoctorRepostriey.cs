using Reservio.DTOS.Doctor;
using Reservio.Models;

namespace Reservio.Services
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
