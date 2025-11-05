using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api.Config;
using web_api.Interface;

namespace web_api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IAccountService _accountService;
        private readonly ApplicationSettings _applicationSettings;
        public TokenService(IAccountService accountService, IOptions<ApplicationSettings> applicationSettings)
        {
            _accountService = accountService;
            _applicationSettings = applicationSettings.Value;
        }
        public async Task<string> GenerateJWTToken(string userIdOrName)
        {
            var user = await _accountService.UserProfile(userIdOrName);
            var userRole = user.UserRoles?.FirstOrDefault()?.Role?.Name;

            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
              new Claim("user_id", user.Id),
              new Claim(_options.ClaimsIdentity.RoleClaimType,userRole),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(2),
                Issuer = _applicationSettings.Issuer,
                Audience = _applicationSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_Secret)),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

    }
}
