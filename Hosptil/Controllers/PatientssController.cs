using AutoMapper;
using Hosptil.DTOS.Patient;
using Hosptil.Models;
using Hosptil.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hosptil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patient;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository patient, IMapper mapper)
        {
            this._patient = patient;
            this._mapper = mapper;
        }
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            List<Patient> patients = await _patient.GetAllPatientAsync();
            if (patients is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<PatientWithoutReversoinDTO>>(patients));
        }
        [HttpPost("CreatePatinet")]
        public async Task<IActionResult> AddPatient(PatientCreationDTO patient)
        {
            if (patient == null)
                return BadRequest();
            var result = await _patient.AddPatientAsync(_mapper.Map<Patient>(patient));
            return CreatedAtRoute("GetPatient", new { patientId = result.PatientId, includeRev = false }, _mapper.Map<PatientWithoutReversoinDTO>(result));

        }
        [HttpGet("{patientId}/{includeRev}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int patientId, bool includeRev)
        {

            Patient patient = await _patient.GetPatientByIdASync(patientId, includeRev);

            if (patient is null)
                return NotFound();
            if (!includeRev)
                return Ok(_mapper.Map<PatientWithoutReversoinDTO>(patient));
            return Ok(patient);
        }
        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdatePatient(int patientId, PatientCreationDTO patientCreation)
        {
            if (patientCreation == null)
            {
                return BadRequest();
            }

            Patient patient = await _patient.GetPatientByIdASync(patientId, false);
            if (patient == null)
            {
                return NotFound();
            }
            await _patient.UpdatePatientAsync(_patient.MapperPatient(patient, patientCreation));

            return NoContent();
        }
        [HttpDelete("{patientId}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            Patient patient = await _patient.GetPatientByIdASync(patientId, false);
            if (patient is null)
            {
                return NotFound("The Patient is not found");
            }
            await _patient.DeletePatienyAsync(patient);
            return NoContent();
        }


    }
}
