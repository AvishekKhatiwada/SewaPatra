using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class AreaService
    {
        private readonly AreaRepository _areaMasterRepository;
        public AreaService(AreaRepository repository)
        {
            _areaMasterRepository = repository;
        }
        public bool InsertArea(Area area)
        {
            return _areaMasterRepository.InsertArea(area);
        }
        public List<Area> GetAllAreas() 
        {
            return _areaMasterRepository.GetAllAreas();
        }
        public Area GetAreaById(int id)
        {
            return _areaMasterRepository.GetAreaById(id);
        }
        public bool UpdateArea(Area area)
        {
            return _areaMasterRepository.UpdateArea(area);
        }
        public bool DeleteArea(int id)
        {
            return _areaMasterRepository.DeleteArea(id);
        }
    }
}
