using Reservio.DTOS.Doctor;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.DotorRepo
{
    public interface IDotorRepository : IBaseRepository<Doctor>
    {
        Task<List<Doctor?>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(int doctorId ,DoctorForAddDto doctor);
        Task DeleteDoctorAsync(Doctor doctor);

    }
}
