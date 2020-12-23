using System.Data.SqlClient;

namespace TestWebChat.Infrastructure.Data
{
    public abstract class SqlConnectionFactory
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
