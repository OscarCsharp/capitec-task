using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface ITransaction
    {
        Task<IEnumerable<Transaction>> GetAll();
        Task Add(TransactionModel model);
        Task Remove(string TransactionIDOrName);
        Task Update(TransactionModel model, string TransactionId);
        Task<Transaction> GetTransaction(string searchTerm);
    }
}
