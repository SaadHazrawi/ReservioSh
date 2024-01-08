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
        public async Task<ActionResult> CheckReservationStatus([FromQuery] string iPAddress)
        {
            var reservationStatus = await _unitOfWork.Reservation.CheckReservationStatus(iPAddress);
            return Ok(reservationStatus);

        }

        /// <summary>
        /// Add a new reservation.
        /// </summary>
        /// <param name="dto">Added reservation data.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost]
        public async Task<ActionResult> Add(ReservationForAddDto dto)
        {
            // Check if the clinic ID exists
            bool clinicExists = await _unitOfWork.Clinics.ExistsAsync(c => c.ClinicId == dto.ClinicId);
            if (clinicExists)
            {
                var reservationStatus = await _unitOfWork.Reservation.AddReservationAsync(dto);
                return Ok(reservationStatus);
            }
            return BadRequest("Adding failed. The clinic does not exist.");
        }



        [HttpDelete]
        public async Task<ActionResult> DeleteReservation(string iPAddress)
        {

            //TODO What is Logic , Issues 1
            //await _reservation.DeleteReservationAsync(iPAddress);
            return NoContent();
        }


        [HttpGet("Clinics")]
        public async Task<IActionResult> GetClinicsForReservations()
        {
            var clinics = await _unitOfWork.Clinics.GetClinicsForReservations();
            return Ok(clinics);
        }


        /// <summary>
        /// Retrieves the reservations in a clinic within a specified date range.
        /// </summary>
        /// <param name="input">The input data specifying the clinic ID and date range.</param>
        /// <returns>The list of reservations in the clinic.</returns>
        [HttpGet("GetReservationsByDate")]
        public async Task<IActionResult> GetReservationsByDate([FromQuery] GetReservationsByDateInput input)
        {
            var reservations = await _unitOfWork.Reservation.FindAllAsync(
                x => x.ClinicId == input.ClinicId && x.BookFor >= input.StartDate && x.BookFor <= input.EndDate,
                new string[] { },
                od => od.Date,
                OrderBy.Descending
            );

            if (reservations == null)
            {
                return NotFound("No reservations found in the specified clinic.");
            }
            //TODO : Nedd mapper
            return Ok(reservations);
        }


    }
}