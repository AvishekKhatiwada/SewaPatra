using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class PaymentVoucherService
    {


        private readonly PaymentVoucherRepository _paymentVoucherRepository;
        public PaymentVoucherService(PaymentVoucherRepository paymentVoucherRepository)
        {
            _paymentVoucherRepository = paymentVoucherRepository;
        }
        public bool InsertPaymentVoucher(PaymentVoucher paymentVoucher)
        {
            return _paymentVoucherRepository.InsertPaymentVoucher(paymentVoucher);
        }
        public List<PaymentVoucher> GetAllPaymentVoucher()
        {
            return _paymentVoucherRepository.GetAllPaymentVoucher();
        }
        public PaymentVoucher GetAllPaymentVoucherById(string id)
        {
            return _paymentVoucherRepository.GetAllPaymentVoucherById(id);
        }
        public bool UpdatePaymentVoucher(PaymentVoucher PaymentVoucher)
        {
            return _paymentVoucherRepository.UpdatePaymentVoucher(PaymentVoucher);
        }
        public bool DeletePaymentVoucher(string id)
        {
            return _paymentVoucherRepository.DeletePaymentVoucher(id);
        }
    }
}
