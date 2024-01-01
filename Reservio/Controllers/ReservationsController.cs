using AutoMapper;
using Reservio.Services.ReservationRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Reservation;
using Reservio.Services.PatientRepo;

namespace Reservio.Controllers
{
    [Route("api/Reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservation;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservation, IMapper mapper)
        {
            this._reservation = reservation;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> CheckReservationStatus([FromQuery] string iPAddress)
        {
            var reservationStatus = await _reservation.CheckReservationStatus(iPAddress);
            return Ok(reservationStatus);

        }


        [HttpPost]
        public async Task<ActionResult> Add(ReservationForAddDto dto)
        {
            //TODO Abdullah ClinicId is Found
            var reservationStatus = await _reservation.AddReservationAsync(dto);
            return Ok(reservationStatus);
        }



        [HttpDelete]
        public async Task<ActionResult> DeleteReservation(string iPAddress)
        {

            //TODO What is Logic , Issues 1
            //await _reservation.DeleteReservationAsync(iPAddress);
            return NoContent();
        }


        [HttpGet("Clinics")]
        public async Task<ActionResult> GetClinics()
        {
            //TODO 
            //var Clinics = await _reservation.GetClinicsForReservationAsync();
            //if (Clinics == null)
            //{
            //    return NotFound();
            //}
            //return Ok(Clinics);

            throw new NotImplementedException();
        }



        /// <summary>
        /// Retrieves the patients present in the clinic on a day.
        /// </summary>
        /// <param name="clinicsId">The ID of the clinic.</param>
        /// <returns>The list of patients in the clinic.</returns>

        [HttpGet("Clinics/{clinicsId}")]
        public async Task<ActionResult> GetClinics(int clinicsId)
        {

            var Clinics = await _reservation.GetPatientsInClinic(clinicsId);
            if (Clinics == null)
            {
                return NotFound();
            }
            return Ok(Clinics);
        }
    }
}