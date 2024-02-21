using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.Core;
using Reservio.DTOS.Reservation;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/Reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationsController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] ReservationFilter input)
        {
            var (reservations, paginationData) = await _unitOfWork.Reservation.GetReservationsByDateAsync(input);
            Response.Headers.Add("x-pagination", paginationData.ToString());

            return Ok(reservations);
        }

        [HttpGet(template: "CheckReservationStatus")]
        public async Task<ActionResult> CheckReservationStatus([FromQuery] string iPAddress)
        {
            var reservationStatus = await _unitOfWork.Reservation.CheckReservationStatusByIPAddress(iPAddress);
            return Ok( reservationStatus);

        }


        [HttpGet("Clinics")]
        public async Task<IActionResult> GetClinicsForReservations()
        {
            var clinics = await _unitOfWork.Clinics.GetClinicsForReservations();
            return Ok(clinics);
        }


        [HttpPost]
        public async Task<ActionResult> Add(ReservationForAddDto dto)
        {
            var reservationStatus = await _unitOfWork.Reservation.AddReservationAsync(dto);
            return Ok(reservationStatus);
        }


        [HttpPut("{reservationId}")]
        public async Task<IActionResult> UpdateReservation(int reservationId, ReservationUpdateDTO reservationUpdateDTO)
        {
            await _unitOfWork.Reservation.UpdateReservationAsync(reservationId, reservationUpdateDTO);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> MarkReservationAsPatientVisitReviewed(int id)
        {
            await _unitOfWork.Reservation.MarkReservationAsPatientVisitReviewedAsync(id);
            return NoContent();
        }

    }
}