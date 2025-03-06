using SewaPatra.DataAccess;
using SewaPatra.Models;


namespace SewaPatra.BusinessLayer
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepository;
        public ReportService(ReportRepository repository)
        {
            _reportRepository = repository;
        }
     
        public List<DonorReport>GetDonorReport() 
        {
            return _reportRepository.GetDonorReport();
        }
       
    }
}
