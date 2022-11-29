using System.Data;

namespace API_schedule.DAO
{
    public interface IScheduleRepository
    {
        DataTable GetFacultyList();
        DataTable GetFormaTimeList();
        DataTable GetGroupList(int IdFormaTime,int IdKurs,int IdF);
        DataTable GetScheduleList(int IdGroup, bool IsWinter);
        DataTable GetCourseList();
        DataTable GetSpecialisationForGroup(int IdGroup);
    }
}
