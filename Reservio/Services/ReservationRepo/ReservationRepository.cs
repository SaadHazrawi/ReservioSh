using Reservio.AppDataContext;
using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.DTOS.Reservation;
using Reservio.Core;
using AutoMapper;
using Reservio.Services.BaseRepo;

namespace Reservio.Services.ReservationRepo;
public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ReservationRepository(DataContext context , IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<ReservationStatus> AddReservationAsync(ReservationForAddDto dto)
    {
        var reservationStatus = await CheckReservationStatus(dto.IPAddress);
        if (!reservationStatus.Stopping)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            await _context.Reservations.AddAsync(reservation);
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
        int countBookings = 0; //TODO To Abdullah

        //TODO TO Abdullah
        //_logger.LogWarning($"IPAddress {iPAddress}  , Date TimeL {DateTimeLocal.GetDate().Date}");

        var reservationStatus = new ReservationStatus();
        if (countBookings > 0)
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



    public async Task<List<Reservation>> GetPatientsInClinic(int clinicId)
    {
        //TODO To Abdullah
        return await _context.Reservations
            .Where(c => c.ClinicId == clinicId
            && c.BookFor.Date == DateTimeLocal.GetDate())
           .ToListAsync();

    }
}
