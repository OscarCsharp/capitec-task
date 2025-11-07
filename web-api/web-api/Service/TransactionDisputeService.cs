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

        public async Task Add(TransactionDisputeModel model)
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

        public async Task<IEnumerable<TransactionDispute>> GetAll()
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
                    d.TransactionDisputeId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    d.TransactionId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(string transactionDisputeIdOrTransactionId)
        {
            var dispute = await _disputeRepository.GetAll()
                .FirstOrDefaultAsync(d =>
                    d.TransactionDisputeId.Equals(transactionDisputeIdOrTransactionId, StringComparison.OrdinalIgnoreCase) ||
                    d.TransactionId.Equals(transactionDisputeIdOrTransactionId, StringComparison.OrdinalIgnoreCase));

            if (dispute != null)
            {
                await _disputeRepository.Delete(dispute);
            }
        }

        public async Task Update(TransactionDisputeModel model, string transactionDisputeId)
        {
            var dispute = await _disputeRepository.GetAll()
                .FirstOrDefaultAsync(d => d.TransactionDisputeId.Equals(transactionDisputeId, StringComparison.OrdinalIgnoreCase));

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