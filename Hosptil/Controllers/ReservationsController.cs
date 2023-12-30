using AutoMapper;
using Hosptil.Services.ReservationRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hosptil.Controllers
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
