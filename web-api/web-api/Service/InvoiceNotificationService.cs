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

        public async Task Add(InvoiceNotificationModel model)
        {
            var notification = new InvoiceNotification
            {
                Id = Guid.NewGuid().ToString(),
                InvoiceId = model.InvoiceId,
                SentDate = DateTime.Now,
                Message = model.Message,
                IsRead = model.IsRead
            };

            await _notificationRepository.Create(notification);
        }

        public async Task<IEnumerable<InvoiceNotification>> GetAll()
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
                    n.Id.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    n.InvoiceId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(string invoiceNotificationIdOrInvoiceId)
        {
            var notification = await _notificationRepository.GetAll()
                .FirstOrDefaultAsync(n =>
                    n.Id.Equals(invoiceNotificationIdOrInvoiceId, StringComparison.OrdinalIgnoreCase) ||
                    n.InvoiceId.Equals(invoiceNotificationIdOrInvoiceId, StringComparison.OrdinalIgnoreCase));

            if (notification != null)
            {
                await _notificationRepository.Delete(notification);
            }
        }

        public async Task Update(InvoiceNotificationModel model, string invoiceNotificationId)
        {
            var notification = await _notificationRepository.GetAll()
                .FirstOrDefaultAsync(n => n.Id.Equals(invoiceNotificationId, StringComparison.OrdinalIgnoreCase));

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