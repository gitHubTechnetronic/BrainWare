using System.Configuration;

namespace Web.DisplayModels
{
    public class BaseRepository
    {

        protected readonly static string _connectionstring = ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString;

    }
}