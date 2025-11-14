using Microsoft.AspNetCore.Mvc;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranch _branchService;

        public BranchController(IBranch branchService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] BranchModel model)
        {
            await _branchService.AddBranch(model);
            return Ok("Branch added successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranches();
            return Ok(branches);
        }

        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<Branch>> GetBranch(string searchTerm)
        {
            var branch = await _branchService.GetBranch(searchTerm);
            if (branch == null)
                return NotFound("Branch not found.");
            return Ok(branch);
        }

        [HttpPut("{branchId}")]
        public async Task<IActionResult> UpdateBranch(string branchId, [FromBody] BranchModel model)
        {
            await _branchService.UpdateBranch(model, branchId);
            return Ok("Branch updated successfully.");
        }

        [HttpDelete("{branchId}")]
        public async Task<IActionResult> DeleteBranch(string branchId)
        {
            await _branchService.RemoveBranch(branchId);
            return Ok("Branch deleted successfully.");
        }
    }
}