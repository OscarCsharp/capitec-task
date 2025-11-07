using Microsoft.AspNetCore.Mvc;
using web_api.Interface;
using web_api.Model;
using web_api.Entities;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoiceService;
        private readonly IInvoiceNotification _notificationService;
        public InvoiceController(IInvoice invoiceService, IInvoiceNotification notificationService)
        {
            _invoiceService = invoiceService;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceModel model)
        {
            await _invoiceService.Add(model);
            return Ok("Invoice added successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAll();
            return Ok(invoices);
        }

        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<Invoice>> GetInvoice(string searchTerm)
        {
            var invoice = await _invoiceService.GetInvoice(searchTerm);
            if (invoice == null)
                return NotFound("Invoice not found.");
            return Ok(invoice);
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(string invoiceId, [FromBody] InvoiceModel model)
        {
            await _invoiceService.Update(model, invoiceId);
            return Ok("Invoice updated successfully.");
        }

        [HttpDelete("{invoiceIdOrUserId}")]
        public async Task<IActionResult> DeleteInvoice(string invoiceIdOrUserId)
        {
            await _invoiceService.Remove(invoiceIdOrUserId);
            return Ok("Invoice deleted successfully.");
        }


        [HttpPost]
        public async Task<IActionResult> AddInvoiceNotification([FromBody] InvoiceNotificationModel model)
        {
            await _notificationService.Add(model);
            return Ok("Notification added successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceNotification>>> GetAllInvoiceNotifications()
        {
            var notifications = await _notificationService.GetAll();
            return Ok(notifications);
        }

        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<InvoiceNotification>> GetInvoiceNotification(string searchTerm)
        {
            var notification = await _notificationService.GetInvoiceNotification(searchTerm);
            if (notification == null)
                return NotFound("Notification not found.");
            return Ok(notification);
        }

        [HttpPut("{notificationId}")]
        public async Task<IActionResult> UpdateInvoiceNotification(string notificationId, [FromBody] InvoiceNotificationModel model)
        {
            await _notificationService.Update(model, notificationId);
            return Ok("Notification updated successfully.");
        }

        [HttpDelete("{notificationIdOrInvoiceId}")]
        public async Task<IActionResult> DeleteInvoiceNotification(string notificationIdOrInvoiceId)
        {
            await _notificationService.Remove(notificationIdOrInvoiceId);
            return Ok("Notification deleted successfully.");
        }
    }
}





