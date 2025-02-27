using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class DonorService
    {
        private readonly DonorRepository _donorRepository;
        public DonorService(IConfiguration configuration)
        {
            _donorRepository = new DonorRepository(configuration);
        }
        public bool InsertDonor(Donor donor)
        {
            return _donorRepository.InsertDonor(donor);
        }
    }
}
