using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{

    public interface IInvoiceNotification
    {
        Task<IEnumerable<InvoiceNotification>> GetAll();
        Task Add(InvoiceNotificationModel model);
        Task Remove(string InvoiceNotificationIDOrName);
        Task Update(InvoiceNotificationModel model, string InvoiceNotificationId);
        Task<InvoiceNotification> GetInvoiceNotification(string searchTerm);
    }
}
