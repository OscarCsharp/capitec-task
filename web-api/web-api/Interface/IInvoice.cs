using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface IInvoice
    {
        Task<IEnumerable<Invoice>> GetAllInvoices();
        Task AddInvoice(InvoiceModel model);
        Task RemoveInvoice(string InvoiceId);
        Task UpdateInvoice(InvoiceModel model, string InvoiceId);
        Task<Invoice> GetInvoice(string searchTerm);
    }
}
