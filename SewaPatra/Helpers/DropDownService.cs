using Microsoft.AspNetCore.Mvc.Rendering;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.Helpers
{
    public class DropDownService
    {
        private readonly DonationBoxService _donationBoxService;
        private readonly CoordinatorService _coordinatorService;
        private readonly DonorService _donorService;
        private readonly AreaService _areaService;
        public DropDownService(DonationBoxService donationBoxService, CoordinatorService coordinatorService,
            DonorService donorService, AreaService areaService)
        {
            _donationBoxService = donationBoxService;
            _coordinatorService = coordinatorService;
            _donorService = donorService;
            _areaService = areaService;
        }
        public List<SelectListItem> GetDonationBoxList()
        {
            List<DonationBox> donationBoxes = _donationBoxService.GetAllDonationBox();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var donationBox in donationBoxes)
            {
                items.Add(new SelectListItem { Text = donationBox.Box_Number, Value = donationBox.Id.ToString() });
            }
            return items;
        }
        public List<SelectListItem> GetCoordinatorList()
        {
            List<Coordinator> coordinators = _coordinatorService.GetAllCoordinator();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var coordinator in coordinators)
            {
                items.Add(new SelectListItem { Text = coordinator.Name, Value = coordinator.Id.ToString() });
            }
            return items;
        }
        public List<SelectListItem> GetDonorList()
        {
            List<Donor> donors = _donorService.GetAllDonor();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var donor in donors)
            {
                items.Add(new SelectListItem { Text = donor.Name, Value = donor.Id.ToString() });
            }
            return items;
        }
        public List<SelectListItem> GetAreaList()
        {
            List<Area> areas = _areaService.GetAllAreas();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var area in areas)
            {
                items.Add(new SelectListItem { Text = area.Area_name, Value = area.Id.ToString() });
            }
            return items;
        }

    }
}
