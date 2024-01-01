using Reservio.DTOS.Schedule;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ScheduleRepo
{
    public interface ISchedulesRepository :IBaseRepository<Schedule>
    {
        Task Add(ScheduleForAddDto dto);
        Task<List<ScheduleDto>> Get();
    }
}
