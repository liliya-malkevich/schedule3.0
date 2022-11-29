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
        private readonly IExamSchedule _examSchedule;
        public ScheduleController(IScheduleRepository scheduleRepository, IExamSchedule examSchedule)
        {
            _scheduleRepository = scheduleRepository;
            _examSchedule = examSchedule;
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

        [Route("course")]
        [HttpGet]
        public IActionResult GetCourse()
        {
            try { return Ok(_scheduleRepository.GetCourseList()); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("groups")]
        [HttpGet]
        public IActionResult GetGroup(int IdFormaTime, int IdKurs, int IdF)
        {
            try { return Ok(_scheduleRepository.GetGroupList(IdFormaTime,IdKurs,IdF)); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("groups/spec")]
        [HttpGet]
        public IActionResult GetSpecialisation(int IdGroup)
        {
            try { return Ok(_scheduleRepository.GetSpecialisationForGroup(IdGroup)); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("exam")]
        [HttpGet]
        public IActionResult GetExamSchedule(int IdGroup, bool IsWinter)
        {
            try { return Ok(_examSchedule.GetScheduleExamList(IdGroup, IsWinter)); }
            catch (Exception e) { return StatusCode(500, e); }
        }
    }
}
