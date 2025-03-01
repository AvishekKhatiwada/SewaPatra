using System.ComponentModel.DataAnnotations;

namespace SewaPatra.Models
{
    public class ReceiptVoucher
    {
        [Key]
        [Required]
        public string R_TranId { get; set; }
        public string Date { get; set; }
        public string Sewapatra_No { get; set; }
        public string Donor { get; set; }
        public string Coordinator { get; set; }
        public string Amount { get; set; }
        public string Next_DueDate { get; set; }
        public string Remarks { get; set; }
    }
}
