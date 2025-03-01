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
        public List<SewaPatraIssue> GetAllSewaPatraIssue()
        {
            return _sewaPatraIssueRepository.GetAllSewaPatraIssue();
        }
        public SewaPatraIssue GetSewaPatraIssueById(string id)
        {
            return _sewaPatraIssueRepository.GetSewaPatraIssueById(id);
        }
        public bool UpdateSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            return _sewaPatraIssueRepository.UpdateSewaPatraIssue(sewaPatraIssue);
        }
        public bool DeleteSewaPatraIssue(string id)
        {
            return _sewaPatraIssueRepository.DeleteSewaPatraIssue(id);
        }
    }
}
