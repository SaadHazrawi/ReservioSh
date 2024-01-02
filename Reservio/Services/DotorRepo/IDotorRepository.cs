using Reservio.DTOS.Doctor;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.DotorRepo
{
    public interface IDotorRepository : IBaseRepository<Doctor>
    {
        Task<List<DoctorWithoutSubstitueDTO?>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(DoctorForAddDto doctor);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(int doctorId ,DoctorForAddDto doctor);
        Task DeleteDoctorAsync(int doctorId);

    }
}
