using System.ComponentModel.DataAnnotations;

namespace SewaPatra.Models
{
    public class SewaPatraReceipt
    {
        [Key]
        public string SPR_TranId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Donor { get; set; }
        [Required]
        public int Coordinator { get; set; }
        [Required]
        public int DonationBox { get; set; }
        [Required]
        public DateTime Receive_Date { get; set; }
        public string? Remarks { get; set; }
    }
}