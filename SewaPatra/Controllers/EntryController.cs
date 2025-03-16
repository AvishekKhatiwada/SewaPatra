using Microsoft.AspNetCore.Mvc;
using SewaPatra.BusinessLayer;
using SewaPatra.Helpers;
using SewaPatra.Models;

namespace SewaPatra.Controllers
{
    public class EntryController : Controller
    {
        private readonly SewaPatraIssueService _sewaPatraIssueService;
        private readonly PaymentVoucherService _paymentVoucherService;
        private readonly ReceiptVoucherService _receiptVoucherService;
        private readonly SewaPatraReceiptService _sewaPatraReceiptService;
        private readonly DropDownService _dropDownService;

        public EntryController(SewaPatraIssueService sewaPatraIssueService, PaymentVoucherService paymentVoucherService,
            ReceiptVoucherService receiptVoucherService, DropDownService dropDownService, SewaPatraReceiptService sewaPatraReceiptService)
        {
            _sewaPatraIssueService = sewaPatraIssueService;
            _paymentVoucherService = paymentVoucherService;
            _receiptVoucherService = receiptVoucherService;
            _dropDownService = dropDownService;
            _sewaPatraReceiptService = sewaPatraReceiptService;
        }
        #region SewaPatra Issue
        public IActionResult SewaPatraIssue()
        {
            ViewBag.DonationBoxes = _dropDownService.GetDonationBoxList();
            ViewBag.Coordinators = _dropDownService.GetCoordinatorList();
            ViewBag.Donors = _dropDownService.GetDonorList();
            ViewBag.Message = TempData["Message"];
            return View();
        }
        public IActionResult SewaPatraIssueList()
        {
            List<SewaPatraIssue> sewaPatraIssue = _sewaPatraIssueService.GetAllSewaPatraIssue();
            ViewBag.Message = TempData["Message"];
            return View(sewaPatraIssue);
        }
        [HttpPost]
        public IActionResult SewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isInserted = _sewaPatraIssueService.InsertSewaPatraIssue(sewaPatraIssue);
                    if (isInserted)
                    {
                        TempData["Message"] = "SewaPatra Issue Added Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Failed to Add SewaPatra Issue";
                    }
                }
                else
                {
                    TempData["Message"] = "Invalid data";
                }
            }
            catch (Exception Ex)
            {
                TempData["Message"] = Ex.Message.ToString();
            }
            return RedirectToAction("SewaPatraIssue");
        }
        public IActionResult EditSewaPatraIssue(string id)
        {
            var sewaPatraIssue = _sewaPatraIssueService.GetSewaPatraIssueById(id);
            ViewBag.DonationBoxes = _dropDownService.GetDonationBoxList();
            ViewBag.Coordinators = _dropDownService.GetCoordinatorList();
            ViewBag.Donors = _dropDownService.GetDonorList();
            if (sewaPatraIssue == null)
            {
                return NotFound();
            }
            return View(sewaPatraIssue);
        }
        [HttpPost]
        public IActionResult EditSewaPatraIssue(SewaPatraIssue sewaPatraIssue)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = _sewaPatraIssueService.UpdateSewaPatraIssue(sewaPatraIssue);
                    if (isUpdated)
                    {
                        TempData["Message"] = "SewaPatra Issue Updated Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Failed to Update SewaPatra Issue";
                    }
                }
                else
                {
                    TempData["Message"] = "Invalid data";
                }
            }
            catch (Exception Ex)
            {
                TempData["Message"] = Ex.Message.ToString();
            }            
            return RedirectToAction("SewaPatraIssueList");
        }
        public IActionResult DeleteSewaPatraIssue(string id)
        {
            try 
            {
                bool isDeleted = _sewaPatraIssueService.DeleteSewaPatraIssue(id);
                if (isDeleted)
                {
                    TempData["Message"] = "SewaPatra Issue Deleted Successfully!";
                }
                else 
                {
                    TempData["Message"] = "Failed To Delete SewaPatra Issue!";
                }
            }      
            catch(Exception Ex)
            {
                TempData["Message"] = Ex.Message.ToString();
            }
            return RedirectToAction("SewaPatraIssueList");
        }
        #endregion
        #region Receipt Voucher
        public IActionResult ReceiptVoucher()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public IActionResult ReceiptVoucher(ReceiptVoucher receiptVoucher)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _receiptVoucherService.InsertReceiptVoucher(receiptVoucher);
                if (isUpdated)
                {
                    TempData["Message"] = "Receipt Voucher Inserted Successfully";
                }
                else
                {
                    TempData["Message"] = "Failed to Insert Receipt Voucher";
                }
            }
            else
            {
                TempData["Message"] = "Invalid data";
            }
            return View();
        }
        public IActionResult ReceiptVoucherList()
        {
            ViewBag.Message = TempData["Message"];
            List<ReceiptVoucher> receiptVoucher = _receiptVoucherService.GetAllReceiptVoucher();
            return View(receiptVoucher);
        }
        #endregion
        #region Payment Voucher
        public IActionResult PaymentVoucher()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        public IActionResult PaymentVoucherList()
        {
            ViewBag.Message = TempData["Message"];
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
                    TempData["Message"] = "Payment Voucher Added Successfully";
                }
                else
                {
                    TempData["Message"] = "Failed to Add Payment Voucher Issue";
                }
            }
            else
            {
                TempData["Message"] = "Invalid data";
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
                    TempData["Message"] = "Payment Voucher Updated Successfully";
                }
                else
                {
                    TempData["Message"] = "Failed to Update Payment Voucher";
                }
            }
            else
            {
                TempData["Message"] = "Invalid data";
            }
            return View();
        }
        public IActionResult DeletePaymentVoucher(string id)
        {
            bool isDeleted = _paymentVoucherService.DeletePaymentVoucher(id);
            return RedirectToAction("PaymentVoucherList");
        }
        #endregion
        #region SewaPatra Receipt
        public IActionResult SewaPatraReceipt()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.DonationBoxes = _dropDownService.GetDonationBoxList();
            ViewBag.Coordinators = _dropDownService.GetCoordinatorList();
            ViewBag.Donors = _dropDownService.GetDonorList();
            return View();
        }
        public IActionResult SewaPatraReceiptList()
        {
            ViewBag.Message = TempData["Message"];
            List<SewaPatraReceipt> sewaPatraReceipt = _sewaPatraReceiptService.GetAllSewaPatraReceipt();
            return View(sewaPatraReceipt);
        }
        [HttpPost]
        public IActionResult SewaPatraReceipt(SewaPatraReceipt sewaPatraReceipt)
        {
            if (ModelState.IsValid)
            {
                bool isInserted = _sewaPatraReceiptService.InsertSewaPatraReceipt(sewaPatraReceipt);
                if (isInserted)
                {
                    TempData["Message"] = "SewaPatra Receipt Added Successfully";
                }
                else
                {
                    TempData["Message"] = "Failed to Add SewaPatra Receipt";
                }
            }
            else
            {
                TempData["Message"] = "Invalid data";
            }
            return View();
        }
        public IActionResult EditSewaPatraReceipt(string id)
        {
            var sewaPatraReceipt = _sewaPatraReceiptService.GetSewaPatraReceiptById(id);
            if (sewaPatraReceipt == null)
            {
                return NotFound();
            }
            return View(sewaPatraReceipt);
        }
        [HttpPost]
        public IActionResult EditSewaPatraReceipt(SewaPatraReceipt sewaPatraReceipt)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _sewaPatraReceiptService.UpdateSewaPatraReceipt(sewaPatraReceipt);
                if (isUpdated)
                {
                    TempData["Message"] = "SewaPatra Receipt Updated Successfully";
                }
                else
                {
                    TempData["Message"] = "Failed to Update SewaPatra Receipt";
                }
            }
            else
            {
                TempData["Message"] = "Invalid data";
            }
            return View();
        }
        public IActionResult DeleteSewaPatraReceipt(string id)
        {
            bool isDeleted = _sewaPatraReceiptService.DeleteSewaPatraReceipt(id);
            return RedirectToAction("SewaPatraReceiptList");
        }
        #endregion
    }
}