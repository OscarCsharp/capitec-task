using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface ITransaction
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task AddTransaction(TransactionModel model);
        Task RemoveTransaction(string TransactionId);
        Task UpdateTransaction(TransactionModel model, string TransactionId);
        Task<Transaction> GetTransaction(string searchTerm);
    }
}
