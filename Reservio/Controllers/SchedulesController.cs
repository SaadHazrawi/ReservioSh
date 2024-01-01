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

            var Schedule = await _unitOfWork.Schedules.Get();
            return Ok(Schedule);
        }
        [HttpPost()]
        public async Task<ActionResult> AddSchedules(ScheduleForAddDto dto)
        {
            await _unitOfWork.Schedules.Add(dto);
            return Ok();
        }
    }
}
