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
        #endregion

    }
}