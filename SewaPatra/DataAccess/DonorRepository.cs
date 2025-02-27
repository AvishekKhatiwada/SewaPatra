using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class DonorRepository
    {
        private readonly string _connectionString;
        public DonorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertDonor(Donor donor)
        {
            return false;
        }
    }
}
