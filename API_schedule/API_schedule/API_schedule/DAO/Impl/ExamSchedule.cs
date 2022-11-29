using API_schedule.DAO.Config;
using System.Data;
using Microsoft.Data.SqlClient;
namespace API_schedule.DAO.Impl
{
    public class ExamSchedule : IExamSchedule
    {
        private readonly DBRepository _repository;
        public ExamSchedule(DBRepository repository)
        {
            _repository = repository;
        }
        public DataTable GetScheduleExamList(int IdGroup, bool IsWinter)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
           {
                 new SqlParameter("@IdGroup", SqlDbType.Int) { Value = IdGroup },
                 new SqlParameter("@IsWinter", SqlDbType.Bit) { Value = IsWinter }
           };
            DataTable table = _repository.ExecuteProc("[sch].[sprSchedule_List]", paramsProc);
            return table;
        }
    }
}
