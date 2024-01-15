using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.Vacation;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Net;

namespace Reservio.Services.VacationRepo
{
    public class VacationRepository : IVacationRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        private ILogger<UnitOfWork> _logger;

        public VacationRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Vacation> AddVacationAsync(VacationAddDTO vacationDto)
        {
            if (vacationDto is null)
            {
                _logger.LogError("Try add null or Empty Vaction");
                throw new APIException(HttpStatusCode.BadRequest, "The Data Is an correict try agien Liter");
            }
            //Check if Doctor in system or not
            bool isValidDoctorWithId = await _context.Doctors
                        .AnyAsync(d => d.DoctorId == vacationDto.DoctorId);
            if (!isValidDoctorWithId)
            {
                _logger.LogError($"Try Add Vaction For Docotr {vacationDto.DoctorId}");
                throw new APIException(HttpStatusCode.NotFound, "try agien with correict Doctor ");
            }
            // Check if the doctor is on the schedule and update to "Disabled"
            Schedule? doctorSchedule = await _context.Schedules
                            .FirstOrDefaultAsync(s => (int)s.DayOfWeek == vacationDto.DateTime.Day
                            && s.DoctorId == vacationDto.DoctorId);
            if (doctorSchedule is not null)
            {
                doctorSchedule.IsDeleted = true;
                _context.Schedules.Update(doctorSchedule);
            }
            Vacation vacation = _mapper.Map<Vacation>(vacationDto);
            await _context.Vacations.AddAsync(vacation);
            await _context.SaveChangesAsync();
            return vacation;
        }
    }
}
