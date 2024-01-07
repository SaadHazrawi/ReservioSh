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

        [HttpGet(template: "GetAllClinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            var clinics = await _unitOfWork.Clinics.GetAllCinicsAsync();
            return Ok(_mapper.Map<List<ClinicDto>>(clinics));
        }


        [HttpPost]
        public async Task<IActionResult> CreationClicnic(ClinicCreationDTO clinicCreationDTO)
        {

            var result = await _unitOfWork.Clinics.AddClinicAsync(clinicCreationDTO);
            return CreatedAtRoute("GetClinic", new { clinicId = result.ClinicId }, _mapper.Map<ClinicDto>(result));
        }

        [HttpGet("{clinicId}", Name = "GetClinic")]
        public async Task<ActionResult> GetClinic(int clinicId)
        {
            var clinic = await _unitOfWork.Clinics.GetClinicByIdAsync(clinicId);

            return Ok(_mapper.Map<ClinicDto>(clinic));
        }
        [HttpPut("{clinicId}")]
        public async Task<IActionResult> UpdateClinic(int clinicId, ClinicForUpdateDTO clinic)
        {
            await _unitOfWork.Clinics.UpdateClinicAsync(clinicId, clinic);

            return NoContent();
        }
        [HttpDelete("{clinicId}")]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            await _unitOfWork.Clinics.DeleteClinicAsync(clinicId);
            return NoContent();
        }
        [HttpPost("{clinicId}")]
        public async Task<IActionResult> ActiviteClinic(int clinicId)
        {
            var activeClinic = await _unitOfWork.Clinics.ReActivateClinicAsync(clinicId);
            return CreatedAtRoute("GetClinic", new { clinicId = activeClinic.ClinicId }, _mapper.Map<ClinicDto>(activeClinic));

        }

    }
}
