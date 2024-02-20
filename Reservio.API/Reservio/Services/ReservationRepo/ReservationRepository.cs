using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservio.AppDataContext;
using Reservio.Core;
using Reservio.DTOS.Reservation;
using Reservio.Enums;
using Reservio.Models;
using Reservio.Services.BaseRepo;
using System.Net;

namespace Reservio.Services.ReservationRepo;
public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UnitOfWork> _logger;

    public ReservationRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger) : base(context)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<ReservationDto>, PaginationMetaData)> GetReservationsByDateAsync(GetReservationsByDateInput dto)
    {
        var query = _context.Reservations as IQueryable<Reservation>;


        query = query.Where(c => c.PatientVisitReviewed == false);

        if (dto.ClinicId > 0)
        {
            query = query.Where(c => c.ClinicId == dto.ClinicId);
        }

        if (dto.StartDate > DateTime.MinValue)
        {
            query = query.Where(c => c.BookFor >= dto.StartDate);
        }

        if (dto.EndDate > DateTime.MinValue)
        {
            query = query.Where(c => c.BookFor <= dto.EndDate);
        }


        var reservation = query.Select(reservation => new ReservationDto
        {
            ReservationId = reservation.ReservationId,
            FirstName = reservation.FirstName,
            LastName = reservation.LastName,
            DateOfBirth = reservation.DateOfBirth,
            Date = reservation.Date,
            BookFor = reservation.BookFor,
            Gender = reservation.Gender,
            PhoneNumber = reservation.PhoneNumber,
            Region = reservation.Region,
            Clinic = _context.Clinics.FirstOrDefault(r => r.ClinicId == reservation.ClinicId)!.Name
        });


        var totalCourses = await reservation.CountAsync();

        var result = reservation
            .OrderBy(c => c.Date)
            .Skip((dto.PageNumber - 1) * dto.PageSize)
            .Take(dto.PageSize);




        var paginationMetaData = new PaginationMetaData(totalCourses, dto.PageSize, dto.PageNumber);

        if (result is null)
        {
            throw new APIException(HttpStatusCode.NotFound, "Not Found Any Reservation in system");
        }

        return (result, paginationMetaData);
    }


    public Task<Reservation> GetReservationByIdAsync(int reservationId)
    {
        //TODO To Saad
        throw new NotImplementedException();
    }
    public async Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto)
    {
        bool clinicExists = await _context.Clinics.AnyAsync(c => c.ClinicId == dto.ClinicId);
        if (!clinicExists)
        {
            throw new APIException(HttpStatusCode.BadRequest, "Adding failed. The clinic does not exist.");
        }

        var reservationStatus = await CheckReservationStatusByIPAddress(dto.IPAddress);
        if (reservationStatus.Status != ReservationState.Successfully)
        {
            return reservationStatus;
        }

        _logger.LogInformation($"IPAddress {dto.IPAddress}, DateTime: {DateTime.Now}");

        bool isAccept = await CheckIfCanAcceptMorePatients(dto.ClinicId);

        if (!isAccept)
        {
            _logger.LogInformation("Try to register in a fully scheduled clinic.");
            reservationStatus.StoppingTo = DateTimeLocal.GetDateTime().ToShortDateString();
            reservationStatus.Status = ReservationState.ClinicFull;
            return reservationStatus;
        }

        var reservation = _mapper.Map<Reservation>(dto);
        reservation.BookFor = ReservationHelper.DetermineBookingDate(DateTimeLocal.GetDateTime());
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        return reservationStatus;
    }

    public async Task<ReservationStatus> UpdateReservationAsync(int reservationId, ReservationUpdateDTO reservationDto)
    {
        var reservation = await GetByIdAsync(reservationId);

        if (reservation is null)
        {
            throw new APIException(HttpStatusCode.NotFound, "Error: The reservation was not found.");
        }

        var reservationStatus = new ReservationStatus()
        {
            Status = ReservationState.Successfully
        };
            
        if (!isValidInSchedule(reservationDto.ClinicId))
        {
            reservationStatus.Status = ReservationState.UnavailableDay;
            _logger.LogInformation("Error: The clinic is not available on the specified day.");

        }

        bool isAccept = await CheckIfCanAcceptMorePatients(reservationDto.ClinicId);

        if (!isAccept)
        {
            _logger.LogInformation("Try to update a reservation in a fully scheduled clinic.");
            reservationStatus.StoppingTo = DateTimeLocal.GetDateTime().ToShortDateString();
            reservationStatus.Status = ReservationState.ClinicFull;
            return reservationStatus;
        }

        _mapper.Map(reservationDto, reservation);
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();

        return reservationStatus;
    }
    public async Task MarkReservationAsPatientVisitReviewedAsync(int Id)
    {
        var reservation = await _context.Reservations.FindAsync(Id);

        if (reservation != null)
        {
            reservation.PatientVisitReviewed = true;
            _context.Update(reservation);
            await _context.SaveChangesAsync();
        }

    }
    public async Task<ReservationStatus> CheckReservationStatusByIPAddress(string iPAddress)
    {
        var DayForBooking = ReservationHelper.DetermineBookingDayOfWeek();

        // TODO 003: Test =>  Complete the conditions for counting reservations based on your requirements.
        var CountReservations = await _context.Reservations.CountAsync(r => r.IPAddress == iPAddress
            && r.BookFor.Day == (int)ReservationHelper.DetermineBookingDayOfWeek());

        _logger.LogInformation($"IPAddress {iPAddress}  , Date TimeL {DateTimeLocal.GetDate().Date}");

        var reservationStatus = new ReservationStatus();
        if (CountReservations > 0)
        {
            //"Make a reservation today. \n You can make another reservation after"
            reservationStatus.Status = ReservationState.Stopping;
            reservationStatus.StoppingTo = DateTimeLocal.GetDate()
                .Date.AddDays(1)
                .AddHours(8)
                .ToString("yyyy/MM/dd hh:mm");
        }
        else
        {
            reservationStatus.Status = ReservationState.Successfully;
        }

        return reservationStatus;
    }
   
    /// <summary>
    /// Check if Clinic is Work in day for the update
    /// </summary>
    /// <param name="clinicId"></param>
    /// <returns></returns>
    private bool isValidInSchedule(int clinicId)
    {
        var valid = _context.Schedules.Any(sc => sc.ClinicId == clinicId
        && (int)sc.Day == (int)ReservationHelper.DetermineBookingDayOfWeek());
        return valid;
    }
    private async Task<bool> CheckIfCanAcceptMorePatients(int clinicId)
    {
        int countPaitentAccepted = await _context.Clinics
        .Where(c => c.ClinicId == clinicId)
        .Select(c => c.AcceptedPatientsCount)
        .FirstOrDefaultAsync();
        var CountReservations = await _context.Reservations.CountAsync(r => r.ClinicId == clinicId
             && r.Date.Day == (int)ReservationHelper.DetermineBookingDayOfWeek());
        return CountReservations >= countPaitentAccepted;
    }
}
