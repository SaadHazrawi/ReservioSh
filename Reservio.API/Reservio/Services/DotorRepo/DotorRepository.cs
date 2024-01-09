using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.Doctor;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Net;

namespace Reservio.Services.DotorRepo
{
    public class DotorRepository : BaseRepository<Doctor>, IDotorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitOfWork> _logger;
        public DotorRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Doctor> AddDoctorAsync(DoctorForAddDto doctor)
        {
            if (doctor is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "you can not add null or empty Doctor");
            }
            Doctor doctor1 = _mapper.Map<Doctor>(doctor);
            await _context.Doctors.AddAsync(doctor1);
            await _context.SaveChangesAsync();
            return doctor1;
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            //i use Get By Id from BaseRepository
            var doctor = await GetByIdAsync(doctorId);
            if (doctor is null)
            {
                _logger.LogError($"Doctor not found with ID: {doctorId}");
                throw new APIException(HttpStatusCode.BadRequest, "Doctor not found");
            }

            doctor.IsDeleted = true;
            //Check if the doctor is register in Schedules delete from table Schedules
            bool isDoctorScheduled = await _context.Schedules
                                        .AnyAsync(s => s.DoctorId == doctorId);
            if (isDoctorScheduled)
            {
                var schedules = await _context.Schedules
                                    .Where(s => s.DoctorId == doctorId)
                                    .ToListAsync();
                schedules.ForEach(schedule => schedule.IsDeleted = true);
                _context.Schedules.UpdateRange(schedules);
            }
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }



        public async Task<List<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.Where(d => !d.IsDeleted).ToListAsync();
            if (doctors is null)
            {
                _logger.LogError("He Try get all doctors but no doctors in data base ");
                throw new APIException(HttpStatusCode.NotFound, "Not Found anything");
            }

            return _mapper.Map<List<DoctorDTO>>(doctors);
        }
        public async Task<Doctor> GetDoctorByIdAsync(int doctorId, bool includeSubstite)
        {
            if (!includeSubstite)
            {
                var doctor = await _context.Doctors
                        .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                        && d.IsDeleted == false);
                if (doctor == null)
                {
                    _logger.LogError($"Try Get Doctor {doctorId} but he not found");
                    throw new APIException(HttpStatusCode.NotFound, "Not found Doctor");
                }
                return doctor;
            }
            else
            {
                var doctor = await _context.Doctors
                    .Include(d => d.Schedules)
                      .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                      && d.IsDeleted == false);
                if (doctor == null)
                {
                    _logger.LogError($"Try Get Doctor {doctorId} but he not found");
                    throw new APIException(HttpStatusCode.NotFound, "Not found Doctor");
                }
                return doctor;
            }
        }
        public async Task<Doctor> UpdateDoctorAsync(int doctorId, DoctorForAddDto dto)
        {
            var doctor = await GetDoctorByIdAsync(doctorId, false);
            if (doctor is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Adding failed. The Doctor does not exist..");
            }
            _mapper.Map(dto, doctor);
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task ReplaceScheduleDoctorAsync(int scheduleId, int newDoctorId)
        {
            var schedule = await _context.Schedules
             .FirstOrDefaultAsync(s => s.ScheduleId == scheduleId);
            if (schedule is null)
            {
                _logger.LogError($"Try replacing the doctor Id{newDoctorId}  schedule Id {scheduleId}");
                throw new APIException(HttpStatusCode.NotFound, "Your sending data is not correct");
            }
            schedule.DoctorId = newDoctorId;
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
        public async Task ReplaceAllSchedulesDoctorAsync(int oldDoctorId, int newDoctorId)
        {
            List<Schedule> schedules = await _context.Schedules.Where(s => s.DoctorId == oldDoctorId).ToListAsync();
            if (schedules is null)
            {
                _logger.LogError($"Try replace with Doctor Id {oldDoctorId} but not found any data");
                throw new APIException(HttpStatusCode.BadRequest, "Check Form data and try again later");
            }
            schedules.ForEach(schedule => schedule.DoctorId = newDoctorId);
            _context.Schedules.UpdateRange(schedules);
            await _context.SaveChangesAsync();
        }
    }
}
