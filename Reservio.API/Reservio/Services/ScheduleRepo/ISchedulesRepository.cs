using Reservio.DTOS.Schedule;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ScheduleRepo
{
    public interface ISchedulesRepository :IBaseRepository<Schedule>
    {
        Task<List<ScheduleDto>> GetAll();
        Task<Schedule> AddAsync(ScheduleForAddDto dto);
        Task<Schedule> UpdateAsync(int scheduleId, ScheduleForUpdateDto dto);
     
    }
}
