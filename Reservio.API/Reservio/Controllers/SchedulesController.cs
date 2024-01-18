using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservio.DTOS.Clinic;
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

        [HttpGet(template:"View")]
        public async Task<ActionResult> GetAll()
        {

            var Schedule = await _unitOfWork.Schedules.GetAll();
            return Ok(Schedule);
        }
        //
        [HttpGet]
        public async Task<ActionResult> GetAllForEdit()
        {

            var Schedule = await _unitOfWork.Schedules.GetAllForEdit();
            return Ok(Schedule);
        }

        [HttpGet("{scheduleId}",Name = "GetById")]
        public async Task<ActionResult> GetById(int scheduleId)
        {
            var Schedule = await _unitOfWork.Schedules.FindAsync(s=>s.ScheduleId == scheduleId);
            return Ok(Schedule);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ScheduleForAddDto dto)
        {
           var schedule = await _unitOfWork.Schedules.AddAsync(dto);
           return CreatedAtAction(
                nameof(GetById),
                new { scheduleId = schedule.ScheduleId }, 
                schedule);
        }

        [HttpDelete("{scheduleId}")]
        public async Task<ActionResult> Delete(int scheduleId)
        {
            await _unitOfWork.Schedules.DeleteAsync(s=>s.ScheduleId == scheduleId);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ScheduleForUpdateDto dto)
        {

            await _unitOfWork.Schedules.UpdateAsync( dto);
            return Ok();
        }
    }
}
