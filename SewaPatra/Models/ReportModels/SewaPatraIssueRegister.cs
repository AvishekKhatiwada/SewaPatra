namespace SewaPatra.Models.ReportModels
{
    public class SewaPatraIssueRegister
    {
        public string TranId { get; set; }
        public string Date { get; set; } // Formatted Entered_Date
        public int DonorId { get; set; } // Donor ID
        public string DonorName { get; set; } // Donor Name
        public string DonorArea { get; set; }
        public int CoordinatorId { get; set; } // Coordinator ID
        public string CoordinatorName { get; set; }
        public string CoordinatorArea { get; set; }
        public string BoxId { get; set; } // DonationBox ID
        public string DonationBox { get; set; } // DonationBox Number
        public string IssueDate { get; set; } // Formatted Issue_Date
        public string Recurring { get; set; }
        public string DueDate { get; set; } // Formatted Due_Date
        public string Remarks { get; set; }
    }
}
