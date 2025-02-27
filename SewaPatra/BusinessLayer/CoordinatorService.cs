using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class CoordinatorService
    {
        private readonly CoordinatorRepository _coordinatorRepository;
        public CoordinatorService(CoordinatorRepository repository)
        {
            _coordinatorRepository = repository;
        }
        public bool InsertCoordinator(Coordinator coordinator)
        {
            return _coordinatorRepository.InsertCoordinator(coordinator);
        }
    }
}
