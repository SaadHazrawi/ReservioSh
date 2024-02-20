using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.AppDataContext;
using Reservio.DTOS.Doctor;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();
            return Ok(doctors);

        }


        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorForAddDto doctor)
        {
            var result = await _unitOfWork.Doctors.AddDoctorAsync(doctor);
            return CreatedAtRoute(nameof(GetDoctor), new { doctorId = result.DoctorId, includeSubstie = false }, _mapper.Map<DoctorDTO>(result));

        }


        [HttpGet("{doctorId}/{includeSubstie}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(int doctorId, bool includeSubstie)
        {
            var doctor = await _unitOfWork.Doctors.GetDoctorByIdAsync(doctorId, includeSubstie);
            return Ok(_mapper.Map<List<DoctorDTO>>(doctor));
        }


        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {

            await _unitOfWork.Doctors.DeleteDoctorAsync(doctorId);
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(DoctorForUpdateDto dto)
        {
            await _unitOfWork.Doctors.UpdateDoctorAsync(dto);
            return NoContent();
        }

        [HttpPut("{scheduleId}/{newDoctorId}")]
        public async Task<IActionResult> ReplaceScheduleDoctor(int scheduleId, int newDoctorId)
        {
            await _unitOfWork.Doctors.ReplaceScheduleDoctorAsync(scheduleId, newDoctorId);
            return NoContent();
        }

        [HttpPut("{oldDoctorId}/{newDoctorId}")]
        public async Task<IActionResult> ReplaceAllSchedulesDoctor(int oldDoctorId, int newDoctorId)
        {
            await _unitOfWork.Doctors.ReplaceAllSchedulesDoctorAsync(oldDoctorId, newDoctorId);
            return NoContent();
        }
    }
}
