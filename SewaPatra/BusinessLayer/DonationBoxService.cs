using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class DonationBoxService
    {
        private readonly DonationBoxRepository _donationBoxRepository;
        public DonationBoxService(DonationBoxRepository repository)
        {
            _donationBoxRepository = repository;
        }

        public bool InsertDonationBox(DonationBox donationBox)
        {
            return _donationBoxRepository.InsertDonationBox(donationBox);
        }
    }
}
