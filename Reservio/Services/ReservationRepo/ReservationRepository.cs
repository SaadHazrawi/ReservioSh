using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using Reservio.Core;
using Reservio.AppDataContext;
using Reservio.Models;
using Reservio.Services;

namespace Reservio.Services.ReservationRepo;
public class ReservationRepository : IReservationRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ReservationRepository> _logger;
    public ReservationRepository(DataContext context, ILogger<ReservationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<ReservationStatus> AddReservationAsync(Reservation reservation)
    {
        var reservationStatus = await CheckReservationStatus(reservation.IPAddress);
        if (!reservationStatus.stopping)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();
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
            reservationStatus.Status = "قم بالحجز اليوم  \n يمكن الحجز مرة اخرة بعد";
            reservationStatus.stoppingTo = DateTimeLocal.GetDate()
                .Date.AddDays(1)
                .AddHours(8)
                .ToString("yyyy/MM/dd hh:mm");
            reservationStatus.stopping = true;
        }

        else
        {
            reservationStatus.Status = "يمكن الحجز";
        }

        return reservationStatus;
    }

    public Task<List<Reservation>> GetAllReservationAsync()
    {
        return _context.Reservations.ToListAsync();
    }

    public Task<Reservation> GetReservationByIdAsync(int reservationId)
    {
        throw new NotImplementedException();
    }

    public Task<Reservation> UpdateReservationAsync(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}
