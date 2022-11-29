using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_schedule.DAO;
using System.Data;

namespace API_schedule.Controllers
{
    [Route("schedule/teacher")]
    [ApiController]
    public class TeacherScheduleController : ControllerBase
    {
        private readonly ITeacherSchedule _scheduleRepository;
       // private readonly IExamSchedule _examSchedule;
        public TeacherScheduleController(ITeacherSchedule scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            //_examSchedule = examSchedule;
        }

        [HttpGet]
        public IActionResult GetTeacherSchedule(int IdTeacher, bool IsWinter)
        {
            try { return Ok(_scheduleRepository.GetScheduleTeacherList(IdTeacher, IsWinter)); }
            catch (Exception e) { return StatusCode(500, e); }
        }

        [Route("find")]
        [HttpGet]
        public IActionResult FindTeacher(string nameF, string nameI, string nameO)
        {
            try { return Ok(_scheduleRepository.FindTeacherbyFIO(nameF,nameI,nameO)); }
            catch (Exception e) { return StatusCode(500, e); }
        }
    }
}
