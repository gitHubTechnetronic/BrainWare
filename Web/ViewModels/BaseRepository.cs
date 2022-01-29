using System.Configuration;

namespace Web.ViewModels
{
    public class BaseRepository
    {

        protected readonly static string _connectionstring = ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString;

    }
}