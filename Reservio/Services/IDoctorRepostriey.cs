using Reservio.DTOS.Doctor;
using Reservio.Models;

namespace Reservio.Services
{
    public interface IDoctorRepostriey
    {
        Task<List<Doctor?>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor?> GetDoctorByIdAsync(Guid doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor doctor);

        //TODO For Saad , Why MapperDoctorForUpdate
        Doctor MapperDoctorForUpdate(Doctor doctor, DoctorCreataionDTO updateDto);
    }
}
