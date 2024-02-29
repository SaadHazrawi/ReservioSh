using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Vacation;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VacationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>Add(VacationAddDTO vacationAddDto)
        {
           var vacation =await _unitOfWork.Vacations.AddVacationAsync(vacationAddDto);

            return Ok(vacation);
        }
    }
}
