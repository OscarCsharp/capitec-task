using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface ITransactionDispute
    {
        Task<IEnumerable<TransactionDispute>> GetAll();
        Task Add(TransactionDisputeModel model);
        Task Remove(string TransactionDisputeIDOrName);
        Task Update(TransactionDisputeModel model, string TransactionDisputeId);
        Task<TransactionDispute> GetTransactionDispute(string searchTerm);
    }
}
