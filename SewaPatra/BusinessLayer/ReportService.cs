using SewaPatra.DataAccess;
using SewaPatra.Models;
using SewaPatra.Models.ReportModels;


namespace SewaPatra.BusinessLayer
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepository;
        public ReportService(ReportRepository repository)
        {
            _reportRepository = repository;
        }        
        public List<SewaPatraIssueRegister> GetSewaPatraIssueRegister()
        {
            return _reportRepository.GetSewaPatraIssueRegister();
        }
    }
}