using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservio.AppDataContext;
using Reservio.Enums;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BIController(IUnitOfWork unitOfWork, IMapper mapper, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet(template: "GetCountByGenderPatient")]
        public async Task<IActionResult> GetCountByGenderPatient()
        {
            var patientsByGender = await _unitOfWork.BI.GetCountByGenderPatient();
            return Ok(patientsByGender);
        }

        [HttpGet(template: "GetPatientInWeek")]
        public async Task<IActionResult> GetPatientInWeek()
        {
            var patientsByGender = await _unitOfWork.BI.GetPatientInWeek();
            return Ok(patientsByGender);
        }


        [HttpGet(template: "GetPatientInClinic")]
        public async Task<IActionResult> GetPatientInClinic()
        {
            var clinicsWithReservationCounts = await _unitOfWork.BI.GetPatientInClinic();
            return Ok(clinicsWithReservationCounts);
        }


        [HttpGet(template: "GetPatientInClinicInDataAsync")]
        public async Task<IActionResult> GetPatientInClinicInDataAsync()
        {
            var data = await _unitOfWork.BI.GetPatientInClinicInDataAsync(TimePeriod.Month);
            return Ok(data);
        }
    }
}
