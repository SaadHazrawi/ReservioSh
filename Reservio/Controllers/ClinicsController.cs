using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Clinic;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicsController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            this._unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllClinics()
        {
            List<Clinic> clinics = await _unitOfWork.Clinics.GetAllCinicsAsync();

            return Ok(_mapper.Map<List<ClinicWithiutAnyThinkAsync>>(clinics));
        }


        [HttpPost]
        public async Task<IActionResult> CreationClicnic(ClinicCreationDTO clinicWith)
        {

            var result = await _unitOfWork.Clinics.AddClinicAsync(_mapper.Map<Clinic>(clinicWith));
            return CreatedAtRoute("GetClinic", new { clinicId = result.ClinicId }, _mapper.Map<ClinicWithiutAnyThinkAsync>(result));
        }

        [HttpGet("{clinicId}", Name = "GetClinic")]
        public async Task<ActionResult> GetClinic(int clinicId)
        {
            var clinic = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);

            return Ok(_mapper.Map<ClinicWithiutAnyThinkAsync>(clinic));
        }
        [HttpPut("{clinicId}")]
        public async Task<IActionResult> UpdateClinic(int clinicId, ClinicForUpdateDTO clinic)
        {
            if (clinic is null)
                return BadRequest();
            Clinic clinic1 = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);

            clinic1.Name = clinic.Name;
            await _unitOfWork.Clinics.UpdateClinicAsync(clinic1);

            return NoContent();
        }
        [HttpDelete("{clinicId}")]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            Clinic clinic = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);
            await _unitOfWork.Clinics.DeleteClinicAsync(clinic);
            return NoContent();
        }
        [HttpPost("{clinicId}")]
        public async Task<IActionResult> ActiviteClinic( int clinicId)
        {
            var activeClinic = await _unitOfWork.Clinics.ActivationClinicAsync(clinicId);
            return CreatedAtRoute("GetClinic", new { clinicId = activeClinic.ClinicId }, _mapper.Map<ClinicWithiutAnyThinkAsync>(activeClinic));

        }

    }
}
