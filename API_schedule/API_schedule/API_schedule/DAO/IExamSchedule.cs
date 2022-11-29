using System.Data;

namespace API_schedule.DAO
{
    public interface IExamSchedule
    {
        DataTable GetScheduleExamList(int IdGroup, bool IsWinter);
    }
}
