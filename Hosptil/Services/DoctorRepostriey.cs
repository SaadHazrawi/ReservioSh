﻿using Hosptil.AppDataContext;
using Hosptil.DTOS.Doctor;
using Hosptil.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Services
{
    public class DoctorRepostriey : IDoctorRepostriey
    {
        private readonly DataContext _context;

        public DoctorRepostriey(DataContext context)
        {
            this._context = context;
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

        public Doctor MapperDoctorForUpdate(Doctor doctor, DoctorCreataionDTO updateDto)
        {
            doctor.FullName = updateDto.FullName;
            doctor.Specialist = updateDto.Specialist;
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
