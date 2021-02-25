using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Test.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class LoginTest : UserTests
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Its possible execute the LOGIN FindByID method.")]
        public async Task FindByID()
        {
            var email = Faker.Internet.Email();
            var returnObj = new
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Login success"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(returnObj);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}