using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using web_api.Config;
using web_api.Data;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;

namespace web_api.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEncryptionService _encryptionService;
        private readonly ApplicationSettings _appSettings;
        private readonly DataContext _context;

        public AccountService(UserManager<User> userManager, RoleManager<Role> roleManager, IEncryptionService encryptionService,
               IOptions<ApplicationSettings> appSettings, DataContext context)
        {
            _userManager = userManager;
            _encryptionService = encryptionService;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<bool> Register(UserModel userModel)
        {
            var existingUser = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userModel.UserName);
            if (existingUser != null) return false;
            var validatedRole = await _roleManager.Roles.Where(x => x.NormalizedName == userModel.Role.ToUpper()).FirstOrDefaultAsync();

            var encryptedData = _encryptionService.CreatePasswordHash(userModel.Password);
            string userId = Guid.NewGuid().ToString();
            var AppUser = new User()
            {
                Id = userId,
                UserName = userModel.UserName,
                EmailAddress = userModel.Email,
                HashedPassword = encryptedData.HashPassword,
                SaltPassword = encryptedData.SaltPassword
            };

            var createUser = await _userManager.CreateAsync(AppUser);
            if (createUser.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var addUserRole = await _userManager.AddToRoleAsync(user, validatedRole.Name);
                    return addUserRole.Succeeded ? true : false;
                }

                return false;
            }
            return false;

        }

        public async Task<bool> Delete(string userIdOrName, bool isSoftDelete)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userIdOrName|| x.Id == userIdOrName);
            if (user != null)
            {
                if (!isSoftDelete)
                {
                    await _userManager.DeleteAsync(user);
                }
                else
                {
                    user.Deactivated = true;
                    await _userManager.UpdateAsync(user);
                }
                return true;
            }
            return false;
        }


        public async Task<bool> Update(UserModel userModel)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userModel.UserName);
            EncryptionResponseModel encryptedData = _encryptionService.CreatePasswordHash(userModel.Password);
            user.HashedPassword = encryptedData.HashPassword;
            user.SaltPassword = encryptedData.SaltPassword;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return true;
            return false;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == username);

            if (user != null)
            {
                var isAuthorized = _encryptionService.VerifyPasswordHash(password, user.HashedPassword, user.SaltPassword);
                if (isAuthorized)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //public async Task<UserProfileDTO> UserProfile(string userIdOrName)
        //{
          //  var user = await GetUser(userIdOrName);
            /*var profile = new UserProfileDTO
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                Deactivated = user.Deactivated,
                IsWhitelisted = user.IsWhitelisted,
                ProjectTokenID = user.ProjectTokenID,
                Active = user.Active,
                ServiceAccount = user.ServiceAccount,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Role = user.UserRoles?.FirstOrDefault()?.Role?.Name,
                TenantId = user.Tenant
            };

            return profile;*/
        //}
        public async Task<User> UserProfile(string userIdOrName)
        {
            if (string.IsNullOrWhiteSpace(userIdOrName))
                return null;

            var user = await _userManager.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(x => x.Id == userIdOrName || x.UserName == userIdOrName);

            // If user is found but navigation properties weren't loaded (e.g., via fallback), reload them
            if (user == null)
            {
                user = await _userManager.FindByIdAsync(userIdOrName)
                     ?? await _userManager.FindByNameAsync(userIdOrName);

                if (user != null)
                {
                    // Manually load roles if needed
                    await _context.Entry(user)
                        .Collection(u => u.UserRoles)
                        .Query()
                        .Include(ur => ur.Role)
                        .LoadAsync();
                }
            }

            return user;
        }
    }
}
