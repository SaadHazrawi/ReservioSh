using Reservio.DTOS.Doctor;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.DotorRepo
{
    public interface IDoctorRepostriey : IBaseRepository<Doctor>
    {
        Task<List<Doctor?>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor doctor);

        //TODO For Saad , Why MapperDoctorForUpdate
        Doctor MapperDoctorForUpdate(Doctor doctor, DoctorCreataionDTO updateDto);
    }
}
