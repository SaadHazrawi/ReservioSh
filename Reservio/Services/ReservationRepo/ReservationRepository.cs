using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using Reservio.Core;
using AutoMapper;
using Reservio.Services.BaseRepo;
using System.ComponentModel;
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


    public async Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto)
    {


        bool clinicExists = await _context.Clinics.AnyAsync(c => c.ClinicId == dto.ClinicId);
        if (!clinicExists)
        {
            throw new APIException(HttpStatusCode.BadRequest, "Adding failed. The clinic does not exist..");
        }

        var reservationStatus = await CheckReservationStatus(dto.IPAddress);
        if (reservationStatus.Stopping)
        {
            return reservationStatus;
        }
        //TODO:Form Saad => To Abdullah he is Working but why we show on CMD ?
        //Why doesn't register in Data Base Or File
        _logger.LogWarning($"IPAddress {dto.IPAddress}, DateTime: {DateTime.Now}");

        int countPaitentAccepte = await _context.Clinics
            .Where(c => c.ClinicId == dto.ClinicId)
            .Select(c => c.CountPaitentAccepte)
            .FirstOrDefaultAsync();


        // TODO 003: Test => Complete the conditions for counting reservations based on your requirements.
        var CountReservations = await _context.Reservations.CountAsync(r => r.ClinicId == dto.ClinicId
        && r.Date.Day == (int)ReservationHelper.DetermineBookingDayOfWeek());

        if (CountReservations >= countPaitentAccepte)
        {
            reservationStatus.Stopping = true;
            reservationStatus.StoppingTo = DateTimeLocal.GetDateTime().ToShortDateString();
            reservationStatus.Status = "The clinic is full.";
            _logger.LogError("Try to register on Tansima Clinic");
            return reservationStatus;
        }


        var reservation = _mapper.Map<Reservation>(dto);
        reservation.BookFor = ReservationHelper.DetermineBookingDate(DateTimeLocal.GetDateTime());
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        return reservationStatus;
    }


    public async Task DeleteReservationAsync(Reservation reservation)
    {
        reservation.IsDeleted = true;
        _context.Update(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task<ReservationStatus> CheckReservationStatus(string iPAddress)
    {
        var DayForBooking = ReservationHelper.DetermineBookingDayOfWeek();

        // TODO 003: Test =>  Complete the conditions for counting reservations based on your requirements.
        var CountReservations = await _context.Reservations.CountAsync(r => r.IPAddress == iPAddress
            && r.BookFor.Day == (int)ReservationHelper.DetermineBookingDayOfWeek());

        //_logger.LogWarning($"IPAddress {iPAddress}  , Date TimeL {DateTimeLocal.GetDate().Date}");

        var reservationStatus = new ReservationStatus();
        if (CountReservations > 0)
        {
            reservationStatus.Status = "Make a reservation today. \n You can make another reservation after";
            reservationStatus.StoppingTo = DateTimeLocal.GetDate()
                .Date.AddDays(1)
                .AddHours(8)
                .ToString("yyyy/MM/dd hh:mm");
            reservationStatus.Stopping = true;
        }
        else
        {
            reservationStatus.Status = "Reservation is possible";
        }

        return reservationStatus;
    }

    public Task<List<Reservation>> GetAllReservationAsync()
    {
        return _context.Reservations.ToListAsync();
    }


    public Task<Reservation> GetReservationByIdAsync(int reservationId)
    {
        //TODO To Saad
        throw new NotImplementedException();
    }


    public Task<Reservation> UpdateReservationAsync(Reservation reservation)
    {
        //TODO To Saad
        throw new NotImplementedException();
    }
}
