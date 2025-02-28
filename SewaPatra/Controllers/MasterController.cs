using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.Controllers
{
    public class MasterController : Controller
    {
        public readonly AreaService _AreaService;
        public readonly CoordinatorService _CoordinatorService;
        public readonly DonationBoxService _DonationBoxService;
        public readonly DonorService _DonorService;

        public MasterController(AreaService areaService,CoordinatorService coordinatorService,DonationBoxService donationBoxService,
            DonorService donorService)
        {
            _AreaService = areaService;
            _CoordinatorService = coordinatorService;
            _DonationBoxService = donationBoxService;
            _DonorService = donorService;
        }
        #region Area
        public IActionResult AreaList() 
        {
            List<Area> areas = _AreaService.GetAllAreas();
            return View(areas);
        }
        public IActionResult Area()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Area(Area area)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _AreaService.InsertArea(area);
                if (isInserted)
                {
                    ViewBag.Message = "Area Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add Area";
                }
            }
            else 
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditArea(int id)
        {
            var area = _AreaService.GetAreaById(id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }
        public IActionResult DeleteArea(int id)
        {
            bool isDeleted = _AreaService.DeleteArea(id);
            return RedirectToAction("AreaList");
        }
        [HttpPost]
        public IActionResult EditArea(Area model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _AreaService.UpdateArea(model);
                if (isUpdated)
                {
                    return RedirectToAction("AreaList");
                }
                ViewBag.Message = "Update failed!";
            }
            return View(model);
        }
        #endregion
        #region Coordinator
        public IActionResult CoordinatorList()
        {

            List<Coordinator> coordinators = _CoordinatorService.GetAllCoordinator();
            return View(coordinators);
        }
        #region Area
      
        public IActionResult Coordinator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Coordinator(Coordinator coordinator)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _CoordinatorService.InsertCoordinator(coordinator);
                if (isInserted)
                {
                    ViewBag.Message = "Coordinator Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add Coordinator";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditCoordinator(int id)
        {
            var coordinator = _CoordinatorService.GetCoordinatorById(id);
            if (coordinator == null)
            {
                return NotFound();
            }
            return View(coordinator);
        }
        public IActionResult DeleteCoordinator(int id)
        {
            bool isDeleted = _CoordinatorService.DeleteCoordinator(id);
            return RedirectToAction("CoordinatorList");
        }
        [HttpPost]
        public IActionResult EditCoordinator(Coordinator model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _CoordinatorService.UpdateCoordintor(model);
                if (isUpdated)
                {
                    return RedirectToAction("CoordinatorList");
                }
                ViewBag.Message = "Update failed!";
            }
            return View(model);
        }
        #endregion
        #endregion
        #region DonationBox

        public IActionResult DonationBoxList()
        {

            List<DonationBox> donationBoxes = _DonationBoxService.GetAllDonationBox();
            return View(donationBoxes);
        }
      

        public IActionResult DonationBox()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DonationBox(DonationBox donationBoxes)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _DonationBoxService.InsertDonationBox(donationBoxes);
                if (isInserted)
                {
                    ViewBag.Message = "Coordinator Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add Coordinator";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditDonationBox(int id)
        {
            var coordinator = _DonationBoxService.GetDonationBoxById(id);
            if (coordinator == null)
            {
                return NotFound();
            }
            return View(coordinator);
        }
        //public IActionResult DeleteDonationBox(int id)
        //{
        //    bool isDeleted = _DonationBoxService.DeleteDonationBox(id);
        //    return RedirectToAction("CoordinatorList");
        //}
        [HttpPost]
        public IActionResult EditDonationBox(DonationBox model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _DonationBoxService.UpdateDonationBox(model);
                if (isUpdated)
                {
                    return RedirectToAction("CoordinatorList");
                }
                ViewBag.Message = "Update failed!";
            }
            return View(model);
        }

        #endregion





        #region Donor

        public IActionResult DonorList()
        {

            List<Donor> donor = _DonorService.GetAllDonor();
            return View(donor);
        }


        public IActionResult Donor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Donor(Donor donor)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _DonorService.InsertDonor(donor);
                if (isInserted)
                {
                    ViewBag.Message = "Coordinator Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add Coordinator";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditDonor(int id)
        {
            var donor = _DonorService.GetDonorById(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }
        public IActionResult DeleteDonationBox(int id)
        {
            bool isDeleted = _DonorService.DeleteDonor(id);
            return RedirectToAction("CoordinatorList");
        }
        [HttpPost]
        public IActionResult EditDonor(Donor model)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _DonorService.UpdateDonor(model);
                if (isUpdated)
                {
                    return RedirectToAction("DonorList");
                }
                ViewBag.Message = "Update failed!";
            }
            return View(model);
        }

        #endregion

    }
}
