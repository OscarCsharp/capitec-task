using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{

    public interface IInvoiceNotification
    {
        Task<IEnumerable<InvoiceNotification>> GetAllInvoiceNotifications();
        Task AddInvoiceNotification(InvoiceNotificationModel model);
        Task RemoveInvoiceNotification(string InvoiceNotificationId);
        Task UpdateInvoiceNotification(InvoiceNotificationModel model, string InvoiceNotificationId);
        Task<InvoiceNotification> GetInvoiceNotification(string searchTerm);
    }
}
