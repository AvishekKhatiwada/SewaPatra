using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.BusinessLayer.Reports;
using SewaPatra.Models;
using SewaPatra.Models.ReportModels;

namespace SewaPatra.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService;
        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult SewaPatraIsueRegister() 
        {
            List<SewaPatraIssueRegister> sewaPatraIssueRegisters = _reportService.GetSewaPatraIssueRegister();
            return View(sewaPatraIssueRegisters);
        }        
        
    }
}