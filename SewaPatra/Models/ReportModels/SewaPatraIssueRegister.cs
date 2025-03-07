namespace SewaPatra.Models.ReportModels
{
    public class SewaPatraIssueRegister
    {
        public int TranId { get; set; }
        public string Date { get; set; } // Formatted Entered_Date
        public int Donor { get; set; } // Donor ID
        public string DonorId { get; set; } // Donor Name
        public string DonorArea { get; set; }
        public int Coordinator { get; set; } // Coordinator ID
        public string CoordinatorName { get; set; }
        public string CoordinatorArea { get; set; }
        public int BoxId { get; set; } // DonationBox ID
        public string DonationBox { get; set; } // DonationBox Number
        public string IssueDate { get; set; } // Formatted Issue_Date
        public bool Recurring { get; set; }
        public string DueDate { get; set; } // Formatted Due_Date
        public string Remarks { get; set; }
    }
}
