using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface ITransactionDispute
    {
        Task<IEnumerable<TransactionDispute>> GetAllTransactionDisputes();
        Task AddTransactionDispute(TransactionDisputeModel model);
        Task RemoveTransactionDispute(string TransactionDisputeId);
        Task UpdateTransactionDispute(TransactionDisputeModel model, string TransactionDisputeId);
        Task<TransactionDispute> GetTransactionDispute(string searchTerm);
    }
}
