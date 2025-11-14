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

        // Invoice Endpoints

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceModel model)
        {
            await _invoiceService.AddInvoice(model);
            return Ok("Invoice added successfully.");
        }

        [HttpGet("GetAllInvoices")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("GetInvoice/{SearchTerm}")]
        public async Task<ActionResult<Invoice>> GetInvoice(string SearchTerm)
        {
            var invoice = await _invoiceService.GetInvoice(SearchTerm);
            if (invoice == null)
                return NotFound("Invoice not found.");
            return Ok(invoice);
        }

        [HttpPut("UpdateInvoice/{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(string invoiceId, [FromBody] InvoiceModel model)
        {
            await _invoiceService.UpdateInvoice(model, invoiceId);
            return Ok("Invoice updated successfully.");
        }

        [HttpDelete("DeleteInvoice/{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(string invoiceId)
        {
            await _invoiceService.RemoveInvoice(invoiceId);
            return Ok("Invoice deleted successfully.");
        }

        // Invoice Notification Endpoints

        [HttpPost("AddInvoiceNotification")]
        public async Task<IActionResult> AddInvoiceNotification([FromBody] InvoiceNotificationModel model)
        {
            await _notificationService.AddInvoiceNotification(model);
            return Ok("Notification added successfully.");
        }

        [HttpGet("GetAllInvoiceNotifications")]
        public async Task<ActionResult<IEnumerable<InvoiceNotification>>> GetAllInvoiceNotifications()
        {
            var notifications = await _notificationService.GetAllInvoiceNotifications();
            return Ok(notifications);
        }

        [HttpGet("GetInvoiceNotification/{SearchTerm}")]
        public async Task<ActionResult<InvoiceNotification>> GetInvoiceNotification(string SearchTerm)
        {
            var notification = await _notificationService.GetInvoiceNotification(SearchTerm);
            if (notification == null)
                return NotFound("Notification not found.");
            return Ok(notification);
        }

        [HttpPut("UpdateInvoiceNotification/{invoiceNotificationId}")]
        public async Task<IActionResult> UpdateInvoiceNotification(string invoiceNotificationId, [FromBody] InvoiceNotificationModel model)
        {
            await _notificationService.UpdateInvoiceNotification(model, invoiceNotificationId);
            return Ok("Notification updated successfully.");
        }

        [HttpDelete("DeleteInvoiceNotification/{invoiceNotificationId}")]
        public async Task<IActionResult> DeleteInvoiceNotification(string invoiceNotificationId)
        {
            await _notificationService.RemoveInvoiceNotification(invoiceNotificationId);
            return Ok("Notification deleted successfully.");
        }
    }
}