
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

        public async Task AddTransaction(TransactionModel model)
        {
            var transaction = new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                UserId = model.CustomerId,
                Date = DateTime.Now,
                Amount = model.Amount,
                BankName = model.BankName,
                AccountNumber = model.AccountNumber,
                AccountType = model.AccountType,
                referenceNumber = model.referenceNumber

            };


            await _transactionRepository.Create(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
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
                    t.TransactionId.ToLower() == searchTerm.ToLower() ||
                    t.UserId.ToLower() == searchTerm.ToLower());
        }

        public async Task RemoveTransaction(string transactionId)
        {
            var transaction = await _transactionRepository.GetAll()
                .FirstOrDefaultAsync(t =>
                    t.TransactionId.ToLower() == transactionId.ToLower() ||
                    t.UserId.ToLower() == transactionId.ToLower());

            if (transaction != null)
            {
                await _transactionRepository.Delete(transaction);
            }
        }

        public async Task UpdateTransaction(TransactionModel model, string transactionId)
        {
            var transaction = await _transactionRepository.GetAll()
                .FirstOrDefaultAsync(t => t.TransactionId.ToLower() == transactionId.ToLower());

            if (transaction != null)
            {
                transaction.Date = DateTime.Now;
                transaction.Amount = model.Amount;
                transaction.BankName = model.BankName;
                transaction.AccountNumber = model.AccountNumber;
                transaction.AccountType = model.AccountType;
                transaction.referenceNumber = model.referenceNumber;

                await _transactionRepository.Update(transaction);
            }
        }
    }
}
