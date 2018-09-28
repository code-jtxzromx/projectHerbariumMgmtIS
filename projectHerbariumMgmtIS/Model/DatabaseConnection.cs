using System.Data;
using System.Data.SqlClient;

namespace projectHerbariumMgmtIS.Model
{
    class DatabaseConnection
    {
        //private SqlConnection connection = new SqlConnection("Server=192.168.43.38,1433; Database=HerbariumDatabase; User ID=sa; Password=1234; Trusted_Connection=False;");
        private SqlConnection connection = new SqlConnection("Server=localhost; Database=HerbariumDatabase; User ID=sa; Password=1234; Connection Timeout=900");

        private SqlCommand command;
        private SqlDataAdapter dataAdapter;

        public bool testConnection()
        {
            bool state = true;
            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                state = false;
            }
            finally
            {
                connection.Close();
            }

            return state;
        }

        public void setQuery(string query) => command = new SqlCommand(query, connection);

        public void setStoredProc(string sproc)
        {
            dataAdapter = new SqlDataAdapter(sproc, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        public void addQueryParameter(string name, SqlDbType dbType, object value)
        {
            SqlParameter parameter = new SqlParameter(name, dbType);
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        public void addProcParameter(string name, SqlDbType dbType, object value)
        {
            SqlParameter parameter = new SqlParameter(name, dbType);
            parameter.Value = value;
            dataAdapter.SelectCommand.Parameters.Add(parameter);
        }

        public SqlDataReader executeResult()
        {
            connection.Open();
            SqlDataReader result = command.ExecuteReader();

            return result;
        }

        public void executeCommand()
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void executeStoredProc()
        {
            connection.Open();
            dataAdapter.SelectCommand.ExecuteScalar();
            connection.Close();
        }

        public int executeProcedure()
        {
            int result = 0;

            dataAdapter.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            connection.Open();
            dataAdapter.SelectCommand.ExecuteScalar();
            result = (int)dataAdapter.SelectCommand.Parameters["@Result"].Value;

            connection.Close();

            return result;
        }

        public void closeResult() => connection.Close();
    }
}
