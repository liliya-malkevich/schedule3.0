using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace API_schedule.DAO.Config
{
    public class DBRepository
    {
        private readonly string _connectionStr;

        public DBRepository(IConfiguration _configuration)
        {
            _connectionStr = _configuration.GetConnectionString("Schedule");
        }

        public string ConnectionStr
        {
            get { return _connectionStr; }
        }

        public DataTable ExecuteProc(string nameProc,
                             SqlParameter[] paramsProc = null,
                             SqlConnection connectionNoMain = null,
                             SqlTransaction transaction = null,
                             int timeout = 480)
        {
            DataTable table = new();
            if (connectionNoMain == null)
            {
                using SqlConnection connection = new(_connectionStr);
                connection.Open();
                using SqlCommand command = new(nameProc, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (paramsProc != null) command.Parameters.AddRange(paramsProc);
                if (transaction != null) command.Transaction = transaction;
                command.CommandTimeout = timeout;
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            else
            {
                using SqlCommand command = new(nameProc, connectionNoMain);
                command.CommandType = CommandType.StoredProcedure;
                if (paramsProc != null) command.Parameters.AddRange(paramsProc);
                if (transaction != null) command.Transaction = transaction;
                command.CommandTimeout = timeout;
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            return table;
        }

        public void ExecuteProcWithoutResult(string nameProc,
                                            SqlParameter[] paramsProc = null,
                                            SqlConnection connectionNoMain = null,
                                            SqlTransaction transaction = null,
                                            int timeout = 480)
        {

            if (connectionNoMain == null)
            {
                using SqlConnection connection = new(_connectionStr);
                connection.Open();
                using SqlCommand command = new(nameProc, connection);
                command.CommandType = CommandType.StoredProcedure;
                if (paramsProc != null) command.Parameters.AddRange(paramsProc);
                if (transaction != null) command.Transaction = transaction;
                command.CommandTimeout = timeout;
                command.ExecuteNonQuery();
            }
            else
            {
                using SqlCommand command = new(nameProc, connectionNoMain);
                command.CommandType = CommandType.StoredProcedure;
                if (paramsProc != null) command.Parameters.AddRange(paramsProc);
                if (transaction != null) command.Transaction = transaction;
                command.CommandTimeout = timeout;
                command.ExecuteNonQuery();
            }
        }
    }
}
