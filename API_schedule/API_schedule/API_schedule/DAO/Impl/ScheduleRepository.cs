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

        public DataTable GetGroupList(int IdFormaTime, int IdKurs, int IdF)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdFormaTime", SqlDbType.Decimal, 18) { Value = IdFormaTime },
                 new SqlParameter("@IdKurs", SqlDbType.Decimal, 18) { Value = IdKurs },
                 new SqlParameter("@IdF", SqlDbType.Decimal, 18) { Value = IdF }
           };
            DataTable table = _repository.ExecuteProc("[dbo].[CGroups_List]", paramsProc);
            return table;
        }

        public DataTable GetScheduleList(int IdGroup, bool IsWinter)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdGroup", SqlDbType.Decimal, 18) { Value = IdGroup },
                 new SqlParameter("@IsWinter", SqlDbType.Bit,1) { Value = IsWinter }
           };
            DataTable table = _repository.ExecuteProc("[sch].[sprSchedule_List]", paramsProc);
            return table;
        }
    }
}
