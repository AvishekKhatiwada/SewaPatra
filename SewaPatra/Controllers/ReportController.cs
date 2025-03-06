using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService;
        


        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
            
        }
       
      
      
        public IActionResult DonorReport()
        {
            List<DonorReport> donorReport = _reportService.GetDonorReport();
            return View(donorReport);
        }
    }
}

