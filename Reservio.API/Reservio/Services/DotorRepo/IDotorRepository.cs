using Reservio.Core;
using Reservio.DTOS.Doctor;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.DotorRepo
{
    public interface IDotorRepository : IBaseRepository<Doctor>
    {
        Task<List<DoctorDTO>> GetAllDoctorsAsync();
        Task<Doctor> AddDoctorAsync(DoctorForAddDto doctor);
        Task<Doctor> GetDoctorByIdAsync(int doctorId, bool includeSubstite);
        Task<Doctor> UpdateDoctorAsync(DoctorForUpdateDto doctor);
        Task DeleteDoctorAsync(int doctorId);
        Task ReplaceScheduleDoctorAsync(int scheduleId,int newDoctorId);
        //TODO:From Saad=> To Abdullah I have created this service for you, if you wish, move it to the Schedule Services
        Task ReplaceAllSchedulesDoctorAsync(int oldDoctorId,int  newDoctorId);

    }
}
