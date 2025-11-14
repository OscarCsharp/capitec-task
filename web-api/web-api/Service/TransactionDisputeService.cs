using Microsoft.EntityFrameworkCore;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class TransactionDisputeService : ITransactionDispute
    {
        private readonly IRepository<TransactionDispute> _disputeRepository;

        public TransactionDisputeService(IRepository<TransactionDispute> disputeRepository)
        {
            _disputeRepository = disputeRepository;
        }

        public async Task AddTransactionDispute(TransactionDisputeModel model)
        {
            var dispute = new TransactionDispute
            {
                TransactionDisputeId = Guid.NewGuid().ToString(),
                TransactionId = model.TransactionId,
                DisputeDate = DateTime.Now,
                Reason = model.Reason,
                ResolutionStatus = "Resolved",
                ResolutionDate = DateTime.Now
            };

            await _disputeRepository.Create(dispute);
        }

        public async Task<IEnumerable<TransactionDispute>> GetAllTransactionDisputes()
        {
            return await _disputeRepository.GetAll()
                .Include(d => d.Transaction)
                .ToListAsync();
        }

        public async Task<TransactionDispute?> GetTransactionDispute(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _disputeRepository.GetAll()
                .Include(d => d.Transaction)
                .FirstOrDefaultAsync(d =>
                    d.TransactionDisputeId.ToLower() == searchTerm.ToLower() ||
                    d.TransactionId.ToLower() == searchTerm.ToLower());
        }

        public async Task RemoveTransactionDispute(string transactionDisputeId)
        {
            var dispute = await _disputeRepository.GetAll()
                .FirstOrDefaultAsync(d =>
                    d.TransactionDisputeId.ToLower() == transactionDisputeId.ToLower() ||
                    d.TransactionId.ToLower() == transactionDisputeId.ToLower());

            if (dispute != null)
            {
                await _disputeRepository.Delete(dispute);
            }
        }

        public async Task UpdateTransactionDispute(TransactionDisputeModel model, string transactionDisputeId)
        {
            var dispute = await _disputeRepository.GetAll()
                .FirstOrDefaultAsync(d => d.TransactionDisputeId.ToString() ==  transactionDisputeId.ToString());

            if (dispute != null)
            {
                dispute.DisputeDate = DateTime.Now;
                dispute.Reason = model.Reason;
                dispute.ResolutionStatus = "Pending";
                dispute.ResolutionDate = DateTime.Now;

                await _disputeRepository.Update(dispute);
            }
        }
    }
}