using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface IInvoice
    {
        Task<IEnumerable<Invoice>> GetAll();
        Task Add(InvoiceModel model);
        Task Remove(string InvoiceIDOrName);
        Task Update(InvoiceModel model, string InvoiceId);
        Task<Invoice> GetInvoice(string searchTerm);
    }
}
