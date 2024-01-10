using Reservio.DTOS.Vacation;
using Reservio.Models;

namespace Reservio.Services.VacationRepo
{
    public interface IVacationRepository
    {
        Task<Vacation> AddVacationAsync(VacationAddDTO vacationDto);
    }
}
