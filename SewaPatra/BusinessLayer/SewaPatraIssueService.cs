using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class SewaPatraIssueService
    {

        private readonly SewaPatraIssueRepository _sewaPatraIssueRepository;
        public SewaPatraIssueService(SewaPatraIssueRepository sewaPatraIssueRepository)
        {
            _sewaPatraIssueRepository = sewaPatraIssueRepository;
        }
        public bool InsertSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            return _sewaPatraIssueRepository.InsertSewaPatraIssue(sewaPatraIssue);
        }
    }
}
