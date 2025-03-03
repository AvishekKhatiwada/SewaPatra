using System.ComponentModel.DataAnnotations;

namespace SewaPatra.Models
{
    public class ReceiptVoucher
    {
        [Key]
        [Required]
        public string R_TranId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int Sewapatra_No { get; set; }
        [Required]
        public int Donor { get; set; }
        [Required]
        public int Coordinator { get; set; }
        public string Amount { get; set; }
        public string Next_DueDate { get; set; }
        public string Remarks { get; set; }
    }
}
