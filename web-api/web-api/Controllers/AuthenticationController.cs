using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_api.Config;
using web_api.Interface;
using web_api.Model;


namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAccountService _accountService;
        private readonly ApplicationSettings _appSettings;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IAccountService accountService, IOptions<ApplicationSettings> appSettings,
               ITokenService tokenService)
        {
            _accountService = accountService;
            _appSettings = appSettings.Value;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var IsAauthenticated = await _accountService.Authenticate(model.UserName, model.Password);
            if (IsAauthenticated)
            {
                var userProfile = await _accountService.UserProfile(model.UserName);
                if (userProfile == null) return BadRequest(new { message = "Error occured while fetching user profile" });

                var token = await _tokenService.GenerateJWTToken(userProfile.UserName);
                return Ok(token);

            }
            return Unauthorized(new { message = "Username or password is incorrect." });
        }
    }
}
