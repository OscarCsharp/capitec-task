using System.ComponentModel.DataAnnotations;
using web_api.Entities;

namespace web_api.Model
{
    public class TransactionModel
    {

        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty;

    }
}
