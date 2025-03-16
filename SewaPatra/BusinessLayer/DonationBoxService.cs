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
        public List<DonationBox> GetAllDonationBox()
        {
            return _donationBoxRepository.GetAllDonationBox();
        }
        public DonationBox GetDonationBoxById(int id)
        {
            return _donationBoxRepository.GetDonationBoxById(id);
        }
        public bool UpdateDonationBox(DonationBox donationBox)
        {
            return _donationBoxRepository.UpdateDonationBox(donationBox);
        }
        public bool DeleteDonationBox(int id)
        {
            return _donationBoxRepository.DeleteDonationBox(id);
        }

    }
}
