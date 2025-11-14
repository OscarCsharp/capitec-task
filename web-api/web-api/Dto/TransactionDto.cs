using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_api.Dto
{
    public class TransactionDto
    {
        public string TransactionId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; } 
        public string AccountType { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty; 
        public string ReferenceNumber { get; set; } = string.Empty;
        public bool IsDisputed { get; set; } 
    }
}

