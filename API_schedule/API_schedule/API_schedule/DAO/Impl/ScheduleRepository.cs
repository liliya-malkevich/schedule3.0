using API_schedule.DAO.Config;
using System.Data;
using Microsoft.Data.SqlClient;

namespace API_schedule.DAO.Impl
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DBRepository _repository;
        public ScheduleRepository(DBRepository repository)
        {
            _repository = repository;
        }

        public DataTable GetFacultyList()
        {
            DataTable table = _repository.ExecuteProc("[sch].[Facultets_List]");
            return table;
        }
        public DataTable GetFormaTimeList()
        {
            DataTable table = _repository.ExecuteProc("[dbo].[CForma_ListFormaTime]");
            return table;
        }

        public DataTable GetCourseList()
        {
            DataTable table = _repository.ExecuteProc("[dbo].[CKurs_PossibleList]");
            return table;
        }
        public DataTable GetGroupList(int IdFormaTime, int IdKurs, int IdF)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdFormaTime",  SqlDbType.Int) { Value = IdFormaTime },
                 new SqlParameter("@IdKurs",  SqlDbType.Int) { Value = IdKurs },
                 new SqlParameter("@IdF",  SqlDbType.Int) { Value = IdF }
           };
            DataTable table = _repository.ExecuteProc("[dbo].[CGroups_List]", paramsProc);
            return table;
        }

        public DataTable GetScheduleList(int IdGroup, bool IsWinter)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdGroup", SqlDbType.Int) { Value = IdGroup },
                 new SqlParameter("@IsWinter", SqlDbType.Bit) { Value = IsWinter }
           };
            DataTable table = _repository.ExecuteProc("[sch].[sprSchedule_List]", paramsProc);
            return table;
        }

        public DataTable GetSpecialisationForGroup(int IdGroup)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdGroup",SqlDbType.Int) { Value = IdGroup },
           };
            DataTable table = _repository.ExecuteProc("[sch].[Groups_ListScPlan]", paramsProc);
            return table;
        }
    }
}
