using System.ComponentModel.DataAnnotations;
using web_api.Entities;

namespace web_api.Model
{
    public class TransactionModel
    {

        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string referenceNumber { get; set; } = string.Empty;

    }
}




