using API_schedule.DAO.Config;
using System.Data;
using Microsoft.Data.SqlClient;

namespace API_schedule.DAO.Impl
{
    public class TeacherSchedule : ITeacherSchedule
    {
        private readonly DBRepository _repository;
        public TeacherSchedule(DBRepository repository)
        {
            _repository = repository;
        }
        public DataTable FindTeacherbyFIO(string nameF, string nameI, string nameO)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
          {
                 new SqlParameter("@nameF", SqlDbType.VarChar) { Value = nameF },
                 new SqlParameter("@nameI", SqlDbType.VarChar) { Value = nameI },
                 new SqlParameter("@nameO", SqlDbType.VarChar) { Value = nameO }
          };
            DataTable table = _repository.ExecuteProc("[sch].[TeacherFindByFIO]", paramsProc);
            return table;
        }
        public DataTable GetScheduleTeacherList(int IdTeacher, bool IsWinter)
        {
            SqlParameter[] paramsProc = new SqlParameter[]
          {
                 new SqlParameter("@IdTeacher", SqlDbType.VarChar) { Value = IdTeacher },
                 new SqlParameter("@IsWinter", SqlDbType.VarChar) { Value = IsWinter }
          };
            DataTable table = _repository.ExecuteProc(" [sch].[sprSchedule_ForTeacher]", paramsProc);
            return table;
        }
    }
}
