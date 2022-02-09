
using System.Data.Common;
using System.Data.SqlClient;

namespace Web.Infrastructure
{

    public class Database
    {
        //var builder = WebApplication.CreateBuilder(args);
        //string connString = builder.Configuration.GetConnectionString("DefaultConnection");

        private readonly SqlConnection _connection;
 
        public Database()
        {
            var connectionString = "Data Source=LOCALHOST;Initial Catalog=BrainWare;Integrated Security=SSPI";
            //var mdf = @"C:\Brainshark\interview\BrainWare\Web\App_Data\BrainWare.mdf";
            //var connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";

            _connection = new SqlConnection(connectionString);

            _connection.Open();
        }

        public DbDataReader ExecuteReader(string query)
        {
           
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader(); // .ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}