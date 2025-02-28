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
        public List<Coordinator> GetAllCoordinator()
        {
            return _coordinatorRepository.GetAllCoordinator();
        }
        public Coordinator GetCoordinatorById(int id)
        {
            return _coordinatorRepository.GetCoordinatorById(id);
        }
        public bool UpdateCoordintor(Coordinator coordinator)
        {
            return _coordinatorRepository.UpdateArea(coordinator);
        }
        public bool DeleteCoordinator(int id)
        {
            return _coordinatorRepository.DeleteCoordinator(id);
        }
    }    
}
