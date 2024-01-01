﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.Core;
using Reservio.DTOS.Clinic;
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

        //[HttpGet(Name = "GetReservationsByDate")]
        //public async Task<IActionResult> GetReservationsByDate(XXXXClinic xXXClinic)
        //{
        //    var patien = _unitOfWork.Reservation.FindAllAsync(x => x.ClinicId == xXXClinic.clinicId
        //          && x.BookFor >= xXXClinic.startDate && x.BookFor <= xXXClinic.endDate, null, od => od.Date, OrderBy.Descending);
        //    if (patien is null)
        //    {
        //        return NotFound("Not Found patien In Clinic Id");
        //    }

        //    return Ok();
        //}
    }
}