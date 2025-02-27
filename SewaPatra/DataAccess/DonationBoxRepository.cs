using SewaPatra.Models;

namespace SewaPatra.DataAccess
{
    public class DonationBoxRepository
    {
        private readonly string _connectionString;

        public DonationBoxRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool InsertDonationBox(DonationBox donationBox)
        {
            return false;
        }
    }
}
