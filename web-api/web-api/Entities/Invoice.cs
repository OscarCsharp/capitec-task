using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class Invoice
    {
        public string InvoiceId { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }

        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public bool IsPaid { get; set; } = false;

        public bool IsOverdue => !IsPaid && DateTime.UtcNow > DueDate;

        public ICollection<InvoiceNotification>? Notifications { get; set; }
    }
}
