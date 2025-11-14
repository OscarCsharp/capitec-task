using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_api.Entities
{
    public class Transaction
    {
        public string TransactionId { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string referenceNumber { get; set; } = string.Empty;
        public bool IsDisputed => Dispute != null;

        public TransactionDispute? Dispute { get; set; }
    }
}


;