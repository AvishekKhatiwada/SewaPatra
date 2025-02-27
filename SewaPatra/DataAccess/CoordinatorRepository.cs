using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class CoordinatorRepository
    {
        private readonly string _connectionString;

        public CoordinatorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertCoordinator(Coordinator coordinator) 
        {
            return false;
        }
    }
}
