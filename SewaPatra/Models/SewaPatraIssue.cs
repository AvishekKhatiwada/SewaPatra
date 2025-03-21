﻿using System.ComponentModel.DataAnnotations;

namespace SewaPatra.Models
{
    public class SewaPatraIssue
    {
        [Key]
        public string TranId { get; set; }
        [Required]
        public DateTime Entered_Date { get; set; }
        [Required]
        public int Donor { get; set; }
        [Required]
        public int Coordinator { get; set; }
        [Required]
        public int DonationBox { get; set; }
        [Required]
        public DateTime Issue_Date { get; set; }
        public string? Recurring { get; set; }
        public DateTime? Due_Date { get; set; }
        public string? Remarks { get; set; }
        public string? DonorName { get; set; }
        public string? Coordinatorname { get; set; }
        public string? DonationBoxName { get; set; }

    }
}