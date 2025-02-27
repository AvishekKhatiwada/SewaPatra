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
        public IActionResult Coordinator()
        {
            return View();
        }
        #endregion
        #region Donor
        public IActionResult Donor()
        {
            return View();
        }
        #endregion
        #region DonationBox
        public IActionResult DonationBox()
        {
            return View();
        }
        #endregion
    }
}
