using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.AppDataContext;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BIController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet(template: "GetCountByGenderPatient")]
        public async Task<IActionResult> GetCountByGenderPatient()
        {
            var patientsByGender = await  _unitOfWork.BI.GetCountByGenderPatient();
            return Ok(patientsByGender);
        }

        [HttpGet(template: "GetPatientInWeek")]
        public async Task<IActionResult> GetPatientInWeek()
        {
            var patientsByGender = await _unitOfWork.BI.GetPatientInWeek();
            return Ok(patientsByGender);
        }
    }
}
