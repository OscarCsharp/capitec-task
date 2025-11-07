using System.ComponentModel.DataAnnotations;
using web_api.Entities;

namespace web_api.Model
{
    public class InvoiceNotificationModel
    {
        public string InvoiceId { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;
    }
}
