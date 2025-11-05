using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_api.Controllers;
using web_api.Interface;
using web_api.Model;
using web_api.Config;
using Moq;

namespace WebApi.Tests
{
    public class AuthenticationControllerTests
    {
        private readonly Mock<IAccountService> _accountServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly AuthenticationController _controller;

        public AuthenticationControllerTests()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _tokenServiceMock = new Mock<ITokenService>();
            _appSettings = Options.Create(new ApplicationSettings());

            _controller = new AuthenticationController(
                _accountServiceMock.Object,
                _appSettings,
                _tokenServiceMock.Object
            );
        }

        [Fact]
        public async Task Login_ReturnsOk_WhenAuthenticated()
        {
            // Arrange
            var model = new LoginModel { UserName = "testuser", Password = "password" };
            var userProfile = new UserProfile { UserName = "testuser" };

            _accountServiceMock.Setup(s => s.Authenticate(model.UserName, model.Password)).ReturnsAsync(true);
            //_accountServiceMock.Setup(s => s.UserProfile(model.UserName)).ReturnsAsync(userProfile);
            _tokenServiceMock.Setup(s => s.GenerateJWTToken(userProfile.UserName)).ReturnsAsync("mocked_token");

            // Act
            var result = await _controller.Login(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("mocked_token", okResult.Value);
        }

        [Fact]
        public async Task Login_ReturnsBadRequest_WhenUserProfileIsNull()
        {
            var model = new LoginModel { UserName = "testuser", Password = "password" };

            _accountServiceMock.Setup(s => s.Authenticate(model.UserName, model.Password)).ReturnsAsync(true);
           // _accountServiceMock.Setup(s => s.UserProfile(model.UserName)).ReturnsAsync((UserProfile)null);

            var result = await _controller.Login(model);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error occured while fetching user profile", ((dynamic)badRequest.Value).message);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenAuthenticationFails()
        {
            var model = new LoginModel { UserName = "testuser", Password = "wrongpassword" };

            _accountServiceMock.Setup(s => s.Authenticate(model.UserName, model.Password)).ReturnsAsync(false);

            var result = await _controller.Login(model);

            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Username or password is incorrect.", ((dynamic)unauthorized.Value).message);
        }
    }

    // Dummy UserProfile class for testing
    public class UserProfile
    {
        public string UserName { get; set; }
    }
}
