using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;

namespace SewaPatra.Controllers
{
    public class EntryController : Controller
    {
        private readonly SewaPatraIssueService _sewaPatraIssueService;
        private readonly PaymentVoucherService _paymentVoucherService;
        private readonly ReceiptVoucherService _receiptVoucherService;

        public EntryController(SewaPatraIssueService sewaPatraIssueService, PaymentVoucherService paymentVoucherService, ReceiptVoucherService receiptVoucherService)
        {
            _sewaPatraIssueService = sewaPatraIssueService;
            _paymentVoucherService = paymentVoucherService;
            _receiptVoucherService = receiptVoucherService;
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
        public IActionResult ReceiptVoucherList()
        {
            List<ReceiptVoucher> receiptVoucher = _receiptVoucherService.GetAllReceiptVoucher();
            return View(receiptVoucher);
        }
        #endregion
        #region Payment Voucher
        public IActionResult PaymentVoucher()
        {
            return View();
        }
        public IActionResult PaymentVoucherList()
        {
            List<PaymentVoucher> paymentVoucher = _paymentVoucherService.GetAllPaymentVoucher();
            return View(paymentVoucher);
        }
        [HttpPost]

        public IActionResult PaymentVoucher(PaymentVoucher paymentVoucher)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _paymentVoucherService.InsertPaymentVoucher(paymentVoucher);
                if (isInserted)
                {
                    ViewBag.Message = "Payment Voucher Added Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Add Payment Voucher Issue";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult EditPaymentVoucher(string id)
        {
            var paymentVoucher = _paymentVoucherService.GetAllPaymentVoucherById(id);
            if (paymentVoucher == null)
            {
                return NotFound();
            }
            return View(paymentVoucher);
        }
        [HttpPost]
        public IActionResult EditPaymentVoucher(PaymentVoucher paymentVoucher)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _paymentVoucherService.UpdatePaymentVoucher(paymentVoucher);
                if (isUpdated)
                {
                    ViewBag.Message = "Payment Voucher Updated Successfully";
                }
                else
                {
                    ViewBag.Message = "Failed to Update Payment Voucher";
                }
            }
            else
            {
                ViewBag.Message = "Invalid data";
            }
            return View();
        }
        public IActionResult DeletePaymentVoucher(string id)
        {
            bool isDeleted = _paymentVoucherService.DeletePaymentVoucher(id);
            return RedirectToAction("PaymentVoucherList");
        }
        #endregion
    }
}