using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.Controllers
{
    public class EntryController : Controller
    {
        private readonly SewaPatraIssueService _sewaPatraIssueService;
        public EntryController(SewaPatraIssueService sewaPatraIssueService)
        {
            _sewaPatraIssueService = sewaPatraIssueService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region SewaPatra Issue
        public IActionResult SewaPatraIssue()
        {
            return View();
        }
        public IActionResult SewaPatraIssueList()
        {
            List<SewaPatraIssue> sewaPatraIssue = _sewaPatraIssueService.GetAllSewaPatraIssue();
            return View(sewaPatraIssue);
        }
        [HttpPost]
        public IActionResult SewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _sewaPatraIssueService.InsertSewaPatraIssue(sewaPatraIssue);
                if (isInserted)
                {
                    ViewBag.Message = "SewaPatra Issue Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add SewaPatra Issue";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditSewaPatraIssue(string id)
        {
            var sewaPatraIssue = _sewaPatraIssueService.GetSewaPatraIssueById(id);
            if (sewaPatraIssue == null)
            {
                return NotFound();
            }
            return View(sewaPatraIssue);
        }
        [HttpPost]
        public IActionResult EditSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _sewaPatraIssueService.UpdateSewaPatraIssue(sewaPatraIssue);
                if (isUpdated)
                {
                    ViewBag.Message = "SewaPatra Issue Updated Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Update SewaPatra Issue";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult DeleteSewaPatraIssue(string id)
        {
            bool isDeleted = _sewaPatraIssueService.DeleteSewaPatraIssue(id);
            return RedirectToAction("SewaPatraIssueList");
        }
        #endregion
        #region Receipt Voucher
        public IActionResult ReceiptVoucher()
        {
            return View();
        }
        #endregion
    }
}