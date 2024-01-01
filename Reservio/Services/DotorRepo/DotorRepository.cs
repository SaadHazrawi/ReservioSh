using Reservio.AppDataContext;
using Reservio.DTOS.Doctor;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.Services.BaseRepo;
using AutoMapper;
using Reservio.Core;
using System.Net;

namespace Reservio.Services.DotorRepo
{
    public class DotorRepository : BaseRepository<Doctor>, IDotorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DotorRepository(DataContext context , IMapper mapper) :base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task DeleteDoctorAsync(Doctor doctor)
        {
            doctor.IsDeleted = true;
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor?>> GetAllDoctorsAsync() =>
                 await _context.Doctors
                .Where(d => !d.IsDeleted)
                .ToListAsync();

        public Task<Doctor?> GetDoctorByIdAsync(int doctorId, bool includeSubstite)
        {
            if (!includeSubstite)
            {
                return _context.Doctors
                        .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                        && d.IsDeleted == false);
            }
            else
            {
                return _context.Doctors
                    .Include(d => d.Substitutes)
                      .FirstOrDefaultAsync(d => d.DoctorId == doctorId
                      && d.IsDeleted == false);
            }
        }

        public Doctor MapperDoctorForUpdate(Doctor doctor, DoctorForAddDto updateDto)
        {
            doctor.FullName = updateDto.FullName;
            doctor.Specialist = updateDto.Specialist;
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(int doctorId , DoctorForAddDto dto)
        {
            var doctor = await GetDoctorByIdAsync(doctorId , false);
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
