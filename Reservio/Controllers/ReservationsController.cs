using AutoMapper;
using Reservio.Services.ReservationRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservation;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservation, IMapper mapper)
        {
            this._reservation = reservation;
            this._mapper = mapper;
        }

    }
}
