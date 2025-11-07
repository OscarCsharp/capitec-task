using System.ComponentModel.DataAnnotations;
using web_api.Entities;

namespace web_api.Model
{
    public class InvoiceModel
    {

        public string BusinessId { get; set; } = string.Empty;

        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; } = false;

    }
}
