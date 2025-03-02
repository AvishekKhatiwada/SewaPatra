namespace SewaPatra.Models
{
    public class PaymentVoucher
    {
        public string P_TranId { get; set; }
        public DateTime Date { get; set; }
        public string Ledger_Name { get; set; }
        public int Coordinator { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}
