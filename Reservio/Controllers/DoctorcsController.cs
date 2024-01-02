using AutoMapper;
using Reservio.AppDataContext;
using Reservio.DTOS.Doctor;
using Reservio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Reservio.Services.DotorRepo;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorcsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DataContext Context { get; set; }
        public DoctorcsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult>GetAllDoctors()
        {
            var doctors=await _unitOfWork.Doctors.GetAllDoctorsAsync();
            return Ok(doctors);

        }


        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorForAddDto doctor)
        {
            //if(doctor is null)
            //    return BadRequest();
            var result=await _unitOfWork.Doctors.AddDoctorAsync(doctor);
            return CreatedAtRoute(nameof(GetDoctor), new { doctorId=result.DoctorId, includeSubstie=false }, _mapper.Map<DoctorWithoutSubstitueDTO>(result));
             
        }


        [HttpGet("{doctorId}/{includeSubstie}",Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(int doctorId,bool includeSubstie)
        {
            var doctor=await _unitOfWork.Doctors.GetDoctorByIdAsync(doctorId, includeSubstie);
            //if(doctor is null)
            //    return NotFound();
            //if(includeSubstie)
            //    return Ok(doctor);
            //else
            return Ok(_mapper.Map<List<DoctorWithoutSubstitueDTO>>(doctor));
        }


        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            //Doctor ? doctor=await _unitOfWork.Doctors.GetDoctorByIdAsync(doctorId,false);
            //if(doctor is null)
            //    return NotFound();
            await _unitOfWork.Doctors.DeleteDoctorAsync(doctorId);
            return NoContent();

        }


        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, DoctorForAddDto dto)
        {
            await _unitOfWork.Doctors.UpdateDoctorAsync(doctorId , dto);          
            return NoContent();
        }
    }
}
