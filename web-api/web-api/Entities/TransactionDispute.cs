using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class TransactionDispute
    {
        public string TransactionDisputeId { get; set; } = string.Empty;

        [Required]
        public string TransactionId { get; set; } = string.Empty;
        public Transaction? Transaction { get; set; } 

        [Required]
        public DateTime DisputeDate { get; set; }

        [Required]
        public string Reason { get; set; } = string.Empty ;

        public string ResolutionStatus { get; set; } = string.Empty; // e.g., Pending, Resolved, Rejected

        public DateTime? ResolutionDate { get; set; }
    }
}

