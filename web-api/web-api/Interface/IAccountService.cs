using web_api.Dto;
using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{
    public interface IAccountService
    {
        Task<bool> Authenticate(string username, string password);
        Task<User> UserProfile(string username);
        Task<bool> Update(UserModel user);
        Task<bool> Delete(string username, bool isSoftDelete);
        Task<bool> Register(UserModel user);

    }
}
