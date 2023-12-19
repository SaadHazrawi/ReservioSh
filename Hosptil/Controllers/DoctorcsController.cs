using AutoMapper;
using Hosptil.AppDataContext;
using Hosptil.DTOS.Doctor;
using Hosptil.Models;
using Hosptil.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hosptil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorcsController : ControllerBase
    {
        private readonly IDoctorRepostriey _doctor;
        private readonly IMapper _mapper;

        public DataContext Context { get; set; }
        public DoctorcsController(IDoctorRepostriey doctor, IMapper mapper)
        {
            this._doctor = doctor;
            this._mapper = mapper;
        }
        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor(DoctorCreataionDTO doctor)
        {
            if(doctor is null)
                return BadRequest();
            var result=await _doctor.AddDoctorAsync(_mapper.Map<Doctor>(doctor));
            return CreatedAtRoute("GetDoctor", new { doctorId=result.DoctorId, includeSubstie=false }, _mapper.Map<DoctorWithoutSubstitueDTO>(result));
             
        }
        [HttpGet("GetDoctor/{doctorId}/{includeSubstie}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(int doctorId,bool includeSubstie)
        {
            var doctor=await _doctor.GetDoctorByIdAsync(doctorId, includeSubstie);
            if(doctor is null)
                return NotFound();
            if(includeSubstie)
                return Ok(doctor);
            else
            return Ok(_mapper.Map<List<DoctorWithoutSubstitueDTO>>(doctor));
        }
    }
}
