using SewaPatra.DataAccess.Reports;
using SewaPatra.Models.ReportModels;

namespace SewaPatra.BusinessLayer.Reports
{
    public class SewaPatraIssueRegisterService
    {
        private readonly SewaPatraIssueRegisterRepos _sewaPatraIssueRegisterRepo;
        public SewaPatraIssueRegisterService(SewaPatraIssueRegisterRepos sewaPatraIssueRegisterRepos)
        {
            _sewaPatraIssueRegisterRepo = sewaPatraIssueRegisterRepos;
        }
        public List<SewaPatraIssueRegister> GetSewaPatraIssueRegisters()
        {
            return _sewaPatraIssueRegisterRepo.GetSewaPatraIssueRegister();
        }
    }
}
