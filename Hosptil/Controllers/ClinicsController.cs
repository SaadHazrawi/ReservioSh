using AutoMapper;
using Reservio.DTOS.Clinic;
using Reservio.Models;
using Reservio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicRepository _clinic;
        private readonly IMapper _mapper;

        public ClinicsController(IClinicRepository clinic, IMapper mapper)
        {
            this._clinic = clinic;
            this._mapper = mapper;
        }
        [HttpGet(template: "GetAllClinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            List<Clinic> clinics = await _clinic.GetAllCinicsAsync();
            if (clinics is null)
                return NotFound("The Clinic Is Empty");
            return Ok(_mapper.Map<List<ClinicWithiutAnyThinkAsync>>(clinics));
        }
        [HttpPost]
        public async Task<IActionResult> CreationClicnic(ClinicCreationDTO clinicWith)
        {

            if (clinicWith is null)
                return BadRequest();
            var result = await _clinic.AddClinicAsync(_mapper.Map<Clinic>(clinicWith));
            return CreatedAtRoute("GetClinic", new { clinicId = result.ClinicId }, _mapper.Map<ClinicWithiutAnyThinkAsync>(result));
        }

        [HttpGet("{clinicId}", Name = "GetClinic")]
        public async Task<ActionResult> GetClinic(int clinicId)
        {
            var clinic = await _clinic.GetClinicByIdAsync(clinicId);
            if (clinic == null)
                return NotFound("This Clinic Is not Found");
            return Ok(_mapper.Map<ClinicWithiutAnyThinkAsync>(clinic));
        }
        [HttpPut("{clinicId}")]
        public async Task<IActionResult> UpdateClinic(int clinicId, ClinicForUpdateDTO clinic)
        {
            Clinic clinic1 = await _clinic.GetClinicByIdAsync(clinicId);
            if (clinic1 is null)
                return NotFound("The Clinic Is not found");
            if (clinic is null)
                return BadRequest();
            clinic1.Name = clinic.Name;
            await _clinic.UpdateClinicAsync(clinic1);

            return NoContent();
        }
        [HttpDelete("{clinicId}")]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            Clinic clinic = await _clinic.GetClinicByIdAsync(clinicId);
            if (clinic is null)
                return NotFound();
            await _clinic.DeleteClinicAsync(clinic);
            return NoContent();
        }
    }
}
