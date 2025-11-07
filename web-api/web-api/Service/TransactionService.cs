
using Microsoft.EntityFrameworkCore;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class TransactionService : ITransaction
    {
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Add(TransactionModel model)
        {
            var transaction = new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                Id = model.CustomerId,
                Date = DateTime.Now,
                Amount = model.Amount,
                Description = model.Description
            };

            await _transactionRepository.Create(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _transactionRepository.GetAll()
                .Include(t => t.User)
                .Include(t => t.Dispute)
                .ToListAsync();
        }

        public async Task<Transaction?> GetTransaction(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _transactionRepository.GetAll()
                .Include(t => t.User)
                .Include(t => t.Dispute)
                .FirstOrDefaultAsync(t =>
                    t.TransactionId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    t.Id.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(string transactionIdOrUserId)
        {
            var transaction = await _transactionRepository.GetAll()
                .FirstOrDefaultAsync(t =>
                    t.TransactionId.Equals(transactionIdOrUserId, StringComparison.OrdinalIgnoreCase) ||
                    t.Id.Equals(transactionIdOrUserId, StringComparison.OrdinalIgnoreCase));

            if (transaction != null)
            {
                await _transactionRepository.Delete(transaction);
            }
        }

        public async Task Update(TransactionModel model, string transactionId)
        {
            var transaction = await _transactionRepository.GetAll()
                .FirstOrDefaultAsync(t => t.TransactionId.Equals(transactionId, StringComparison.OrdinalIgnoreCase));

            if (transaction != null)
            {
                transaction.Date = DateTime.Now;
                transaction.Amount = model.Amount;
                transaction.Description = model.Description;

                await _transactionRepository.Update(transaction);
            }
        }
    }
}
