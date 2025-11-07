using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class Transaction
    {
        public string TransactionId { get; set; } = string.Empty;


        [Required]
        public string Id { get; set; } = string.Empty;
        public User? User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsDisputed => Dispute != null;

        public TransactionDispute? Dispute { get; set; }
    }
}
