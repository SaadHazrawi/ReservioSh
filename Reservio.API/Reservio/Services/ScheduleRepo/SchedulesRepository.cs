using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.Schedule;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Net;

namespace Reservio.Services.ScheduleRepo
{
    public class SchedulesRepository : BaseRepository<Schedule>, ISchedulesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitOfWork> _logger;
        public SchedulesRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// Adds a new schedule based on the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO containing the schedule data to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="APIException">Thrown when the schedule already exists.</exception>
        public async Task<Schedule> AddAsync(ScheduleForAddDto dto)
        {
            var existingSchedule = _context.Schedules.FirstOrDefault(s =>
                s.DoctorId == dto.DoctorId && s.ClinicId == dto.ClinicId && s.DayOfWeek == dto.DayOfWeek);

            if (existingSchedule is not null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Schedule already exists");
            }
            var schedule = _mapper.Map<Schedule>(dto);
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        public async Task<List<ScheduleDto>> GetAll()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Clinic)
                .Include(s => s.Doctor)
                .ToListAsync();

            var scheduleDtos = _mapper.Map<List<ScheduleDto>>(schedules);

            if (scheduleDtos.Count == 0)
            {
                throw new APIException(HttpStatusCode.BadRequest, "No schedules found.");
            }

            return scheduleDtos;
        }

        public async Task<Schedule> UpdateAsync(int scheduleId, ScheduleForUpdateDto dto)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(s => s.ScheduleId == scheduleId);
            if (schedule == null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Schedule not found");
            }


            _mapper.Map(dto, schedule);
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

    }
}
