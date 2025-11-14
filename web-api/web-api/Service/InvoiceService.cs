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

        public async Task AddInvoice(InvoiceModel model)
        {
            var invoice = new Invoice
            {
                InvoiceId = Guid.NewGuid().ToString(),
                UserId = model.BusinessId,
                InvoiceNumber = model.InvoiceNumber,
                IssueDate = model.IssueDate,
                DueDate = model.DueDate,
                Amount = model.Amount,
                IsPaid = model.IsPaid
            };

            await _invoiceRepository.Create(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
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
                .FirstOrDefaultAsync(i => i.InvoiceId.ToLower() ==  searchTerm.ToLower() || i.UserId.ToLower() == searchTerm.ToLower() || i.InvoiceNumber.ToLower() == searchTerm.ToLower());
        }

        public async Task RemoveInvoice(string invoiceId)
        {
            var invoice = await _invoiceRepository.GetAll()
                .FirstOrDefaultAsync(i => i.InvoiceId.ToLower() == invoiceId.ToLower());

            if (invoice != null)
            {
                await _invoiceRepository.Delete(invoice);
            }
        }

        public async Task UpdateInvoice(InvoiceModel model, string invoiceId)
        {
            var invoice = await _invoiceRepository.GetAll()
                .FirstOrDefaultAsync(i => i.InvoiceId.ToLower() == invoiceId.ToLower());

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