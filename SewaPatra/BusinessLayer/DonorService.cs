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
        public List<Donor> GetAllDonor()
        {
            return _donorRepository.GetAllDonor();
        }
        public Donor GetDonorById(int id)
        {
            return _donorRepository.GetDonorById(id);
        }
        public bool UpdateDonor(Donor donor)
        {
            return _donorRepository.UpdateDonor(donor);
        }
        public bool DeleteDonor(int id)
        {
            return _donorRepository.DeleteDonor(id);
        }
    }
}
