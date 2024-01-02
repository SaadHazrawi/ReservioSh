using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Controllers;
using Reservio.Core;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using AutoMapper;
using Reservio.Core;
using System.Net;
using Reservio.DTOS.Clinic;

namespace Reservio.Services.ClinicRepo
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitOfWork> _logger;

        public ClinicRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<Clinic>> GetAllCinicsAsync()
        {
            List<Clinic> clinics = await _context.Clinics.Where(c => !c.IsDeleted).ToListAsync();
            if (clinics is null)
                throw new APIException(HttpStatusCode.NotFound,"Not Found Any Clinics in your system");
             return clinics;
        }
        public async Task<Clinic> AddClinicAsync(Clinic clinic)
        {
            if(clinic is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Add Empty or null Clinic please try again with corriect data ....");
            }
            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }


        public async Task<Clinic?> GetClinicByIdAsync(int clinicId)
        {

            Clinic ?clinic= await _context.Clinics
                                .FirstOrDefaultAsync(c => c.ClinicId == clinicId
                                && c.IsDeleted == false);
            if (clinic is null)
                throw new APIException(HttpStatusCode.NotFound, "Not found Clinic");
            return clinic;
        }

        public async Task<Clinic> UpdateClinicAsync(Clinic clinic)
        {
            if(clinic is null)
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Edit Empty or null Clinic please try again with corriect data ....");
            _context.Update(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }

        public async Task DeleteClinicAsync(Clinic clinic)
        {
            if (clinic is null)
                throw new APIException(HttpStatusCode.BadRequest, "you Can not Delete Clinic ....");
            clinic.IsDeleted = true;
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task<Clinic> ActivationClinicAsync(int clincicId)
        {
            Clinic? unActiveClinic = await _context.Clinics
                .FirstOrDefaultAsync(c => c.ClinicId == clincicId && c.IsDeleted);
            if (unActiveClinic is null)
            {
                throw new APIException(HttpStatusCode.NotFound, "This Clinic Is not Found or not Delete From System");
            }
            unActiveClinic.IsDeleted = false;
            _context.Clinics.Update(unActiveClinic);
            await _context.SaveChangesAsync();
            return unActiveClinic;
        }



        public async Task<List<ClinicDto>> GetClinicsForReservations()
        {
            var dayOfWeek = ReservationHelper.DetermineBookingDayOfWeek();
            // TODO: I am Abdullah, what is better 😕😵 ??
            //An additional requirement to check whether the number of patients admitted to the clinic is greater than the number of current bookings.
            //Is the condition required to ensure that the clinic has spaces available for new bookings?
            //TODO:Saad=>Yes i Think it's better choice
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
