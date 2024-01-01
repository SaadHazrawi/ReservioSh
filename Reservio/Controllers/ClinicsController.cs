using AutoMapper;
using Reservio.DTOS.Clinic;
using Reservio.Models;
using Microsoft.AspNetCore.Mvc;
using Reservio.Services.ClinicRepo;
using Reservio.Services.BaseRepo;
using Reservio.Core;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicsController(  IMapper mapper,IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        [HttpGet(template: "GetAllClinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            List<Clinic> clinics = await _unitOfWork.Clinics.GetAllCinicsAsync();
            if (clinics is null)
                return NotFound("The Clinic Is Empty");
            return Ok(_mapper.Map<List<ClinicWithiutAnyThinkAsync>>(clinics));
        }
        [HttpPost]
        public async Task<IActionResult> CreationClicnic(ClinicCreationDTO clinicWith)
        {

            if (clinicWith is null)
                return BadRequest();
            var result = await _unitOfWork.Clinics.AddClinicAsync(_mapper.Map<Clinic>(clinicWith));
            return CreatedAtRoute("GetClinic", new { clinicId = result.ClinicId }, _mapper.Map<ClinicWithiutAnyThinkAsync>(result));
        }

        [HttpGet("{clinicId}", Name = "GetClinic")]
        public async Task<ActionResult> GetClinic(int clinicId)
        {
            var clinic = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);
            if (clinic == null)
                return NotFound("This Clinic Is not Found");
            return Ok(_mapper.Map<ClinicWithiutAnyThinkAsync>(clinic));
        }
        [HttpPut("{clinicId}")]
        public async Task<IActionResult> UpdateClinic(int clinicId, ClinicForUpdateDTO clinic)
        {
            Clinic clinic1 = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);
            if (clinic1 is null)
                return NotFound("The Clinic Is not found");
            if (clinic is null)
                return BadRequest();
            clinic1.Name = clinic.Name;
            await _unitOfWork.Clinics.UpdateClinicAsync(clinic1);

            return NoContent();
        }
        [HttpDelete("{clinicId}")]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            Clinic clinic = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);
            if (clinic is null)
                return NotFound();
            await _unitOfWork.Clinics.DeleteClinicAsync(clinic);
            return NoContent();
        }
        [HttpGet("{clinicId}", Name = "GetClinicByDate")]
        public async Task<IActionResult> GetClinicByDate(XXXXClinic xXXClinic)
        {
            var patien = _unitOfWork.Reservation.FindAllAsync(x => x.ClinicId == xXXClinic.clinicId
                  && x.BookFor >= xXXClinic.startDate && x.BookFor <= xXXClinic.endDate, null, od => od.Date, OrderBy.Descending);
            if (patien is null)
            {
                return NotFound("Not Found patien In Clinic Id");
            }
            
            return Ok();
        }

    }
}
