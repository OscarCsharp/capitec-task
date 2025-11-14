using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class InvoiceNotification
    {
        public string InvoiceNotificationId { get; set; } = string.Empty;

        [Required]
        public string InvoiceId { get; set; } = string.Empty ;
        public Invoice? Invoice { get; set; }

        [Required]
        public DateTime SentDate { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;
    }
}
