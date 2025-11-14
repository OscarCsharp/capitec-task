using Microsoft.EntityFrameworkCore;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class InvoiceNotificationService : IInvoiceNotification
    {
        private readonly IRepository<InvoiceNotification> _notificationRepository;

        public InvoiceNotificationService(IRepository<InvoiceNotification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task AddInvoiceNotification(InvoiceNotificationModel model)
        {
            var notification = new InvoiceNotification
            {
                InvoiceNotificationId = Guid.NewGuid().ToString(),
                InvoiceId = model.InvoiceId,
                SentDate = DateTime.Now,
                Message = model.Message,
                IsRead = model.IsRead
            };

            await _notificationRepository.Create(notification);
        }

        public async Task<IEnumerable<InvoiceNotification>> GetAllInvoiceNotifications()
        {
            return await _notificationRepository.GetAll()
                .Include(n => n.Invoice)
                .ToListAsync();
        }

        public async Task<InvoiceNotification?> GetInvoiceNotification(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _notificationRepository.GetAll()
                .Include(n => n.Invoice)
                .FirstOrDefaultAsync(n =>
                    n.InvoiceNotificationId.ToLower() == searchTerm.ToLower() ||
                    n.InvoiceId.ToLower() == searchTerm.ToLower());
        }

        public async Task RemoveInvoiceNotification(string invoiceNotificationId)
        {
            var notification = await _notificationRepository.GetAll()
                .FirstOrDefaultAsync(n =>
                    n.InvoiceNotificationId.ToLower() == invoiceNotificationId.ToLower() ||
                    n.InvoiceId.ToLower() == invoiceNotificationId.ToLower());

            if (notification != null)
            {
                await _notificationRepository.Delete(notification);
            }
        }

        public async Task UpdateInvoiceNotification(InvoiceNotificationModel model, string invoiceNotificationId)
        {
            var notification = await _notificationRepository.GetAll()
                .FirstOrDefaultAsync(n => n.InvoiceNotificationId.ToLower() == invoiceNotificationId.ToLower());

            if (notification != null)
            {
                notification.SentDate = DateTime.Now;
                notification.Message = model.Message;
                notification.IsRead = model.IsRead;

                await _notificationRepository.Update(notification);
            }
        }
    }
}