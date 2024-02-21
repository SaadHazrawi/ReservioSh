using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Doctor;
using Reservio.DTOS.Patient;
using Reservio.Migrations;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(PatientFilter patientFilter)
        {
            var (patient, paginationData) = await _unitOfWork.Patients.GetAllPatientsAsync(patientFilter);
            Response.Headers.Add("x-pagination", paginationData.ToString());
            return Ok(patient);

        }

        /// <summary>
        /// Retrieves a patient by ID.
        /// </summary>
        /// <param name="patientId">The ID of the patient.</param>
        /// <param name="includeRevision">Whether to include the patient's revision information.</param>
        /// <returns>The patient.</returns>
        [HttpGet("{patientId}/{includeRevision}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int patientId, bool includeRevision)
        {
            var patient = await _unitOfWork.Patients.GetPatientByIdAsync(patientId, includeRevision);

            if (!includeRevision)
                return Ok(_mapper.Map<PatientWithoutReversoinDTO>(patient));

            return Ok(patient);
        }


        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientCreationDTO patientCreationDto)
        {
            var createdPatient = await _unitOfWork.Patients.AddPatientAsync(patientCreationDto);
            var patientId = createdPatient.PatientId;
            var patientDto = _mapper.Map<PatientWithoutReversoinDTO>(createdPatient);

            return CreatedAtRoute(nameof(GetPatient), new { patientId, includeRevision=false }, patientDto);
        }


  

        [HttpPut("{patientId}")]
        public async Task<IActionResult> Update(PatientUpdateDTO dto)
        {
            await _unitOfWork.Patients.UpdatePatientAsync(dto);
            return NoContent();
        }


        [HttpDelete("{patientId}")]
        public async Task<IActionResult> Delete(int patientId)
        {
            await _unitOfWork.Patients.DeletePatientAsync(patientId);
            return NoContent();
        }


    }
}
