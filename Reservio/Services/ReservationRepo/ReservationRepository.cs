using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using Reservio.Core;
using Reservio.AppDataContext;
using Reservio.Models;
using Reservio.Services;
using AutoMapper;

namespace Reservio.Services.ReservationRepo;
public class ReservationRepository : IReservationRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ReservationRepository> _logger;
    private readonly IMapper _mapper;
    public ReservationRepository(DataContext context, ILogger<ReservationRepository> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto)
    {
        var reservationStatus = await CheckReservationStatus(dto.IPAddress);
        if (!reservationStatus.Stopping)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            await _context.Reservations.AddAsync(reservation);

        }
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
        int countBookings = await _context.Reservations.CountAsync(b => b.IPAddress == iPAddress
                                         && b.Date.Date == DateTimeLocal.GetDate().Date);
        _logger.LogWarning($"IPAddress {iPAddress}  , Date TimeL {DateTimeLocal.GetDate().Date}");
        var reservationStatus = new ReservationStatus();
        if (countBookings >= 3)
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

    public Task<Reservation> GetReservationByIdAsync(Guid reservationId)
    {
        //TODO To Saad
        throw new NotImplementedException();
    }

    public Task<Reservation> UpdateReservationAsync(Reservation reservation)
    {
        //TODO To Saad
        throw new NotImplementedException();
    }



    public async Task<List<Reservation>> GetPatientsInClinic(Guid clinicId)
    {
        //TODO To Abdullah
        return await _context.Reservations
            .Where(c => c.ClinicId == clinicId
            && c.BookFor.Date == DateTimeLocal.GetDate())
           .ToListAsync();

    }
}
