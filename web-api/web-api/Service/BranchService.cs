using Microsoft.EntityFrameworkCore;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class BranchService : IBranch
    {
        private readonly IRepository<Branch> _branchRepository;

        public BranchService(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task AddBranch(BranchModel model)
        {
            var branch = new Branch
            {
                BranchId = Guid.NewGuid().ToString(),
                Name = model.Name,
                Location = model.Location
            };

            await _branchRepository.Create(branch);
        }

        public async Task<IEnumerable<Branch>> GetAllBranches()
        {
            return await _branchRepository.GetAll().ToListAsync();
        }

        public async Task<Branch?> GetBranch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _branchRepository.GetAll()
                .FirstOrDefaultAsync(b =>
                    b.BranchId.ToLower() == searchTerm.ToLower() ||
                    b.Name.ToLower() == searchTerm.ToLower());
        }

        public async Task RemoveBranch(string branchId)
        {
            var branch = await _branchRepository.GetAll()
                .FirstOrDefaultAsync(b => b.BranchId.ToLower() == branchId.ToLower());

            if (branch != null)
            {
                await _branchRepository.Delete(branch);
            }
        }

        public async Task UpdateBranch(BranchModel model, string branchId)
        {
            var branch = await _branchRepository.GetAll()
                .FirstOrDefaultAsync(b => b.BranchId.ToLower() == branchId.ToLower());

            if (branch != null)
            {
                branch.Name = model.Name;
                branch.Location = model.Location;

                await _branchRepository.Update(branch);
            }
        }
    }
}