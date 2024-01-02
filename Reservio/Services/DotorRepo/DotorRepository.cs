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
        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
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
            if(doctor is null)
            {
                _logger.LogError($"Try to delete doctor not found with ID : {doctorId} ");
                throw new APIException(HttpStatusCode.BadRequest, "Error Try agian");
            }
            doctor.IsDeleted = true;
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }


        //TODO Saad => Not Good Code
        public async Task<List<DoctorWithoutSubstitueDTO?>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.Where(d => !d.IsDeleted).ToListAsync();
            if (doctors is null)
            {
                _logger.LogError("He Try get all doctors but no doctors in data base ");
                throw new APIException(HttpStatusCode.NotFound, "Not Found anything");
            }

            return _mapper.Map<List<DoctorWithoutSubstitueDTO>>(doctors);
        }
        public async Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite)
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
    }
}
