using SewaPatra.DataAccess;
using SewaPatra.Models;

namespace SewaPatra.BusinessLayer
{
    public class SewaPatraReceiptService
    {
        private readonly SewaPatraReceiptRepository _sewaPatraReceiptRepository;
        public SewaPatraReceiptService(SewaPatraReceiptRepository sewaPatraReceiptRepository)
        {
            _sewaPatraReceiptRepository = sewaPatraReceiptRepository;
        }
        public bool InsertSewaPatraReceipt(SewaPatraReceipt sewaPatraReceipt)
        {
            return _sewaPatraReceiptRepository.InsertSewaPatraReceipt(sewaPatraReceipt);
        }
        public List<SewaPatraReceipt> GetAllSewaPatraReceipt()
        {
            return _sewaPatraReceiptRepository.GetAllSewaPatraReceipt();
        }
        public SewaPatraReceipt GetSewaPatraReceiptById(string id)
        {
            return _sewaPatraReceiptRepository.GetSewaPatraReceiptById(id);
        }
        public bool UpdateSewaPatraReceipt(SewaPatraReceipt sewaPatraReceipt)
        {
            return _sewaPatraReceiptRepository.UpdateSewaPatraReceipt(sewaPatraReceipt);
        }
        public bool DeleteSewaPatraReceipt(string id)
        {
            return _sewaPatraReceiptRepository.DeleteSewaPatraReceipt(id);
        }
    }
}
