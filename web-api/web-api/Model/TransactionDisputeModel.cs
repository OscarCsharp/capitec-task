using System.ComponentModel.DataAnnotations;

namespace web_api.Model
{
    public class TransactionDisputeModel
    {
        public string TransactionId { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
