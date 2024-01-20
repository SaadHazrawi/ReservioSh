using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.AppDataContext;
using Reservio.DTOS.Clinic;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public ClinicsController(IMapper mapper, IUnitOfWork unitOfWork, DataContext context)
        {

            _mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._context = context;
        }

        [HttpGet]
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


        [HttpPut]
        public async Task<IActionResult> UpdateClinic(ClinicForUpdateDTO clinic)
        {
            await _unitOfWork.Clinics.UpdateClinicAsync(clinic.ClinicId, clinic);

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
        [HttpGet(template: "ClinicStatistics")]
        public async Task<IActionResult> GetClinicsStatistics()
        {
            var clinicsStatistics =await _unitOfWork.Clinics.GetClinicsStatisticsAsync();
            return Ok(clinicsStatistics);
        }
    }
}
