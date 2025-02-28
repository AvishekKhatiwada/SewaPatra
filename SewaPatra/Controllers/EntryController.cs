using Microsoft.AspNetCore.Mvc;

namespace SewaPatra.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region SewaPatra Issue
        public IActionResult SewaPatraIssue()
        {
            return View();
        }

        #endregion

    }
}