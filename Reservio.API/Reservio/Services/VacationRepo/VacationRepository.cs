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
            if (vacationDto == null)
            {
                _logger.LogError("Attempted to add null or empty vacation");
                throw new APIException(HttpStatusCode.BadRequest, "Invalid data provided. Please try again.");
            }

            // Check if the doctor exists in the system
            int isValidDoctorWithId =  _context.Doctors.Count(d => d.DoctorId == vacationDto.DoctorId);
            if (isValidDoctorWithId == 0)
            {
                _logger.LogError($"Attempted to add vacation for non-existent doctor with ID: {vacationDto.DoctorId}");
                throw new APIException(HttpStatusCode.NotFound, "Please try again with a correct doctor ID.");
            }

            //// Check if the doctor is scheduled
            Schedule? doctorSchedule = await _context.Schedules.FirstOrDefaultAsync(s =>
                s.Day == vacationDto.DateTime.DayOfWeek && s.DoctorId == vacationDto.DoctorId);

            if (doctorSchedule == null)
            {
                _logger.LogError($"Doctor {vacationDto.DoctorId} is not scheduled on {vacationDto.DateTime.DayOfWeek}");
                throw new APIException(HttpStatusCode.NotFound, "Doctor is not scheduled on the specified day.");
            }

            // Map VacationAddDTO to Vacation entity
            Vacation vacation = _mapper.Map<Vacation>(vacationDto);
       
            // Add vacation to database
            await _context.Vacations.AddAsync(vacation);
            await _context.SaveChangesAsync();

            return vacation;
        }
    }
}
