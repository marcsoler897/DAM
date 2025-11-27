using Microsoft.Data.SqlClient;

namespace DAW.Services
{
    public class DAWDBConnection
    {
        private readonly string _connectionString;
        public SqlConnection? sqlConnection;
        public DAWDBConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Open()
        {
            sqlConnection = new SqlConnection(_connectionString);

            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Close()
        {
            sqlConnection!.Close();
        }
    }
}
