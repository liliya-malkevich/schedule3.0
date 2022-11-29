using System.Data;

namespace API_schedule.DAO
{
    public interface ITeacherSchedule
    {
        DataTable FindTeacherbyFIO(string nameF, string nameI, string nameO);
        DataTable GetScheduleTeacherList(int IdTeacher, bool IsWinter);
    }
}
