using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_schedule.DAO;
using System.Data;

namespace API_schedule.Controllers
{
    [Route("schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        public IActionResult GetSchedule(int IdGroup, bool IsWinter)
        {
            try { return Ok(_scheduleRepository.GetScheduleList(IdGroup, IsWinter)); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("faculty")]
        [HttpGet]
        public IActionResult GetFaculty()
        {
            try { return Ok(_scheduleRepository.GetFacultyList()); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("forma_time")]
        [HttpGet]
        public IActionResult GetFormaTime()
        {
            try { return Ok(_scheduleRepository.GetFormaTimeList()); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("groups")]
        [HttpGet]
        public IActionResult GetGroup(int IdFormaTime, int IdKurs, int IdF)
        {
            try { return Ok(_scheduleRepository.GetGroupList(IdFormaTime,IdKurs,IdF)); }
            catch (Exception e) { return StatusCode(500, e); }
        }
    }
}
