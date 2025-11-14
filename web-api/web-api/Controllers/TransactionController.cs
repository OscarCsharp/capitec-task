using Microsoft.AspNetCore.Mvc;
using web_api.Dto;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;

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

        // Transactions

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactions();
            if (transactions == null) return NoContent();

            var transactionDtos = new List<TransactionDto>();
            foreach (var transaction in transactions) {
                var transactionDto = await TransactionDataMapping(transaction);
                transactionDtos.Add(transactionDto);
            }
            return Ok(transactionDtos);
        }

        [HttpGet("GetUserTransactions/{userId}")]
        public async Task<IActionResult> GetUserTransactions(string userId)
        {
            var transactions = await _transactionService.GetAllTransactions();
            if (transactions == null) return NoContent();

            var userTransactions = transactions.Where(x => x.UserId == userId).ToList();

            var transactionDtos = new List<TransactionDto>();
            foreach (var transaction in userTransactions)
            {
                var transactionDto = await TransactionDataMapping(transaction);
                transactionDtos.Add(transactionDto);
            }
            return Ok(transactionDtos);
        }

        [HttpGet("GetTransaction/{searchTerm}")]
        public async Task<IActionResult> GetTransaction(string searchTerm)
        {
            var transaction = await _transactionService.GetTransaction(searchTerm);
            if (transaction == null)
                return NotFound(new { message = "Transaction not found." });

            var transactionDto = await TransactionDataMapping(transaction);
            return Ok(transactionDto);
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionModel model)
        {
            await _transactionService.AddTransaction(model);
            return Ok(new { message = "Transaction created successfully." });
        }

        [HttpPut("UpdateTransaction/{transactionId}")]
        public async Task<IActionResult> UpdateTransaction(string transactionId, [FromBody] TransactionModel model)
        {
            await _transactionService.UpdateTransaction(model, transactionId);
            return Ok(new { message = "Transaction updated successfully." });
        }

        [HttpDelete("RemoveTransaction/{transactionId}")]
        public async Task<IActionResult> RemoveTransaction(string transactionId)
        {
            await _transactionService.RemoveTransaction(transactionId);
            return Ok(new { message = "Transaction removed successfully." });
        }

        // Transaction Disputes

        [HttpGet("GetAllTransactionDisputes")]
        public async Task<IActionResult> GetAllTransactionDisputes()
        {
            var disputes = await _disputeService.GetAllTransactionDisputes();
            return Ok(disputes);
        }

        [HttpGet("GetDispute/{searchTerm}")]
        public async Task<IActionResult> GetDispute(string searchTerm)
        {
            var dispute = await _disputeService.GetTransactionDispute(searchTerm);
            if (dispute == null)
                return NotFound(new { message = "Dispute not found." });

            return Ok(dispute);
        }

        [HttpPost("AddTransactionDispute")]
        public async Task<IActionResult> AddTransactionDispute([FromBody] TransactionDisputeModel model)
        {
            await _disputeService.AddTransactionDispute(model);
            return Ok(new { message = "Dispute created successfully." });
        }

        [HttpPut("UpdateTransactionDispute/{disputeId}")]
        public async Task<IActionResult> UpdateTransactionDispute(string disputeId, [FromBody] TransactionDisputeModel model)
        {
            await _disputeService.UpdateTransactionDispute(model, disputeId);
            return Ok(new { message = "Dispute updated successfully." });
        }

        [HttpDelete("RemoveTransactionDispute/{disputeId}")]
        public async Task<IActionResult> RemoveTransactionDispute(string disputeIdOrTransactionId)
        {
            await _disputeService.RemoveTransactionDispute(disputeIdOrTransactionId);
            return Ok(new { message = "Dispute removed successfully." });
        }

        private async Task<TransactionDto> TransactionDataMapping(Transaction transaction )
        {
            var transactionDisputed = await _disputeService.GetTransactionDispute(transaction.TransactionId);
            var isDisputed = transactionDisputed != null ? true : false;
            var data = new TransactionDto 
            {
                TransactionId = transaction.TransactionId,
                CustomerId = transaction.UserId,
                Amount = transaction.Amount,
                AccountType = transaction.AccountType,
                BankName = transaction.BankName,
                ReferenceNumber = transaction.referenceNumber,
                AccountNumber = transaction.AccountNumber,
                IsDisputed = isDisputed
            };
            return data;
        }
    }
}


