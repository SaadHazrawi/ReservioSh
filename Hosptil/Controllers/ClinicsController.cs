using AutoMapper;
using Hosptil.AppDataContext;
using Hosptil.DTOS.Clinic;
using Hosptil.Models;
using Hosptil.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hosptil.Controllers
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
        [HttpPost]
        public async Task <IActionResult> CreationClicnic(ClinicCreationDTO clinicWith)
        {
            if (clinicWith is null)
                return BadRequest();
            var result= await _clinic.AddClinicAsync(_mapper.Map<Clinic>(clinicWith));
            return CreatedAtRoute("GetClinic", new { clinicId = result.ClinicId}, _mapper.Map<ClinicWithiutAnyThinkAsync>(result));
        }
   
        [HttpGet("GetClinic/{clinicId}", Name = "GetClinic")]
        public async Task<ActionResult> GetClinic(int clinicId)
        {
            var clinic=await _clinic.GetClinicByIdAsync(clinicId);
            if (clinic == null)
                return NotFound("This Clinic Is not Found");

            return Ok(_mapper.Map<ClinicWithiutAnyThinkAsync>(clinic));
            
        }
    }
}
