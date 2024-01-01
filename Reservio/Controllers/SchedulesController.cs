using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Schedule;
using Reservio.Models;
using Reservio.Services.BaseRepo;

namespace Reservio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SchedulesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SchedulesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult> GetSchedules()
        {

            //TODO : Abdullah => GetSchedules
            //var Schedules = await _unitOfWork.S.GetSchedules();
            //if (Schedules == null)
            //{
            //    return NotFound();
            //}
            //return Ok(_mapper.Map<List<ScheduleDto>>(Schedules));
            return NotFound();
        }
        [HttpPost()]
        public async Task<ActionResult> AddSchedules(ScheduleForAddDto dto)
        {
            await _unitOfWork.Schedules.Add(dto);
            return Ok();
        }
    }
}
