using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.AppDataContext;
using Reservio.DTOS.Doctor;
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
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _unitOfWork.Doctors.GetAllDoctorsAsync();
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

        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, DoctorForAddDto dto)
        {
            await _unitOfWork.Doctors.UpdateDoctorAsync(doctorId, dto);
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
