using AutoMapper;
using Hosptil.DTOS.Patient;
using Hosptil.Models;
using Hosptil.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hosptil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patient;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository patient,IMapper mapper)
        {
            this._patient = patient;
            this._mapper = mapper;
        }
        [HttpPost("CreatePatinet")]
        public async Task<IActionResult> AddPatient(PatientCreationDTO patient)
        {
            if (patient == null)
              return BadRequest();
            var result = await _patient.AddPatientAsync(_mapper.Map<Patient>(patient));
            return CreatedAtRoute("GetPatient",new { patientId=result.PatientId, includeRev=false }, result);
           
        }
        [HttpGet("{patientId}/{includeRev}", Name = "GetPatient")]
        public async Task<IActionResult> GetPatient(int patientId,bool includeRev)
        {
            
            Patient patient = await _patient.GetPatientByIdASync(patientId, includeRev);

            if (patient is null)
                return NotFound();
            if (!includeRev)
                 return Ok(_mapper.Map<PatientWithoutReversoinDTO>(patient));
            return Ok(patient);
        }
        [HttpDelete("{patientId}")]
        public async Task<IActionResult> Delete(int patientId)
            =>NotFound();


    }
}
