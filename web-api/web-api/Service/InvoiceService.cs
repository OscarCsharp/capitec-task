using Microsoft.EntityFrameworkCore;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class InvoiceService : IInvoice
    {
        private readonly IRepository<Invoice> _invoiceRepository;

        public InvoiceService(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task Add(InvoiceModel model)
        {
            var invoice = new Invoice
            {
                InvoiceId = Guid.NewGuid().ToString(),
                Id = model.BusinessId,
                InvoiceNumber = model.InvoiceNumber,
                IssueDate = model.IssueDate,
                DueDate = model.DueDate,
                Amount = model.Amount,
                IsPaid = model.IsPaid
            };

            await _invoiceRepository.Create(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _invoiceRepository.GetAll()
                .Include(i => i.User)
                .Include(i => i.Notifications)
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoice(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _invoiceRepository.GetAll()
                .Include(i => i.User)
                .Include(i => i.Notifications)
                .FirstOrDefaultAsync(i =>
                    i.InvoiceId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    i.Id.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    i.InvoiceNumber.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(string invoiceIdOrUserId)
        {
            var invoice = await _invoiceRepository.GetAll()
                .FirstOrDefaultAsync(i =>
                    i.InvoiceId.Equals(invoiceIdOrUserId, StringComparison.OrdinalIgnoreCase) ||
                    i.Id.Equals(invoiceIdOrUserId, StringComparison.OrdinalIgnoreCase));

            if (invoice != null)
            {
                await _invoiceRepository.Delete(invoice);
            }
        }

        public async Task Update(InvoiceModel model, string invoiceId)
        {
            var invoice = await _invoiceRepository.GetAll()
                .FirstOrDefaultAsync(i => i.InvoiceId.Equals(invoiceId, StringComparison.OrdinalIgnoreCase));

            if (invoice != null)
            {
                invoice.InvoiceNumber = model.InvoiceNumber;
                invoice.IssueDate = model.IssueDate;
                invoice.DueDate = model.DueDate;
                invoice.Amount = model.Amount;
                invoice.IsPaid = model.IsPaid;

                await _invoiceRepository.Update(invoice);
            }
        }
    }
}