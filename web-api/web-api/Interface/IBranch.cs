using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface IBranch
    {
        Task<IEnumerable<Branch>> GetAllBranches();
        Task AddBranch(BranchModel model);
        Task RemoveBranch(string BranchId);
        Task UpdateBranch(BranchModel model, string AppointmentId);
        Task<Branch> GetBranch(string searchTerm);
    }
}
