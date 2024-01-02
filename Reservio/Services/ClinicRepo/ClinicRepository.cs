using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.Services.BaseRepo;
using AutoMapper;
using Reservio.Core;
using System.Net;
using Reservio.DTOS.Clinic;

namespace Reservio.Services.ClinicRepo
{
    public class ClinicRepository :BaseRepository<Clinic>, IClinicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClinicRepository(DataContext context ,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Clinic?>> GetAllCinicsAsync()
        {
            return await _context.Clinics.Where(c => !c.IsDeleted).ToListAsync();
        }
        public async Task<Clinic> AddClinicAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }


        public async Task<Clinic?> GetClinicByIdAsync(int clinicId)
        {

            return await _context.Clinics
                                .FirstOrDefaultAsync(c => c.ClinicId == clinicId
                                && c.IsDeleted == false);
        }

        public async Task<Clinic> UpdateClinicAsync(Clinic clinic)
        {
            _context.Update(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }

        public async Task DeleteClinicAsync(Clinic clinic)
        {
            clinic.IsDeleted = true;
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }



        public async Task<List<ClinicDto>> GetClinicsForReservations()
        {
            var dayOfWeek = ReservationHelper.DetermineBookingDayOfWeek();
            //TODO
            //An additional requirement to check whether the number of patients admitted to the clinic is greater than the number of current bookings.
            //Is the condition required to ensure that the clinic has spaces available for new bookings?
            var clinics = await _context.Schedules
            .Where(s => s.DayOfWeek == dayOfWeek && s.Clinic.CountPaitentAccepte > s.Clinic.Reservations.Count)
            .Select(s => s.Clinic)
            .ToListAsync();

            if (clinics.Count == 0)
            {
                throw new APIException(HttpStatusCode.NotFound, "No available clinics for reservations");
            }

            var clinicDtos = _mapper.Map<List<ClinicDto>>(clinics);
            return clinicDtos;
        }


    }
}
