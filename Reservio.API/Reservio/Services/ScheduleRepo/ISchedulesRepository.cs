using Reservio.DTOS.Schedule;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ScheduleRepo
{
    public interface ISchedulesRepository :IBaseRepository<Schedule>
    {
        Task<List<ScheduleDto>> GetAll();
        Task<ScheduleResponse> GetAllForEdit();
        Task<Schedule> AddAsync(ScheduleForAddDto dto);
        Task<Schedule> UpdateAsync(  ScheduleForUpdateDto dto);
     
    }
}
