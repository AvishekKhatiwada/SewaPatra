using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class ReceiptVoucherService
    {
        private readonly ReceiptVoucherRepository _ReceiptVoucherRepository;
        public ReceiptVoucherService(ReceiptVoucherRepository ReceiptVoucherRepository)
        {
            _ReceiptVoucherRepository = ReceiptVoucherRepository;
        }
        public bool InsertReceiptVoucher(ReceiptVoucher ReceiptVoucher)
        {
            return _ReceiptVoucherRepository.InsertReceiptVoucher(ReceiptVoucher);
        }
        public List<ReceiptVoucher> GetAllReceiptVoucher()
        {
            return _ReceiptVoucherRepository.GetAllReceiptVoucher();
        }
    }
}
