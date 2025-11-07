using Microsoft.AspNetCore.Mvc;
using web_api.Interface;
using web_api.Model;
using web_api.Entities;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transactionService;
        private readonly ITransactionDispute _disputeService;

        public TransactionController(ITransaction transactionService, ITransactionDispute disputeService)
        {
            _transactionService = transactionService;
            _disputeService = disputeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAll();
            return Ok(transactions);
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetTransaction(string searchTerm)
        {
            var transaction = await _transactionService.GetTransaction(searchTerm);
            if (transaction == null)
                return NotFound(new { message = "Transaction not found." });

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionModel model)
        {
            await _transactionService.Add(model);
            return Ok(new { message = "Transaction created successfully." });
        }

        [HttpPut("{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(string transactionId, [FromBody] TransactionModel model)
        {
            await _transactionService.Update(model, transactionId);
            return Ok(new { message = "Transaction updated successfully." });
        }

        [HttpDelete("{transactionIdOrUserId}")]
        public async Task<IActionResult> RemoveTransaction(string transactionIdOrUserId)
        {
            await _transactionService.Remove(transactionIdOrUserId);
            return Ok(new { message = "Transaction removed successfully." });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTransactionDisputes()
        {
            var disputes = await _disputeService.GetAll();
            return Ok(disputes);
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetDispute(string searchTerm)
        {
            var dispute = await _disputeService.GetTransactionDispute(searchTerm);
            if (dispute == null)
                return NotFound(new { message = "Dispute not found." });

            return Ok(dispute);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionDispute([FromBody] TransactionDisputeModel model)
        {
            await _disputeService.Add(model);
            return Ok(new { message = "Dispute created successfully." });
        }

        [HttpPut("{disputeId}")]
        public async Task<IActionResult> UpdateTransactionDispute(string disputeId, [FromBody] TransactionDisputeModel model)
        {
            await _disputeService.Update(model, disputeId);
            return Ok(new { message = "Dispute updated successfully." });
        }

        [HttpDelete("{disputeIdOrTransactionId}")]
        public async Task<IActionResult> RemoveTransactionDispute(string disputeIdOrTransactionId)
        {
            await _disputeService.Remove(disputeIdOrTransactionId);
            return Ok(new { message = "Dispute removed successfully." });
        }
    }
}






