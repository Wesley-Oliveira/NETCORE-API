using System.Runtime.Intrinsics.X86;
using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.Delete
{
    public class DeletedOKTest
    {
        private UsersController _controller;
        [Fact(DisplayName = "Its possible execute the DELETE user method.")]
        public async Task TestDelete()
        {
            var serviceMock = new Mock<IUserService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);

            var serviceMockDel = new Mock<IUserService>();
            serviceMockDel.Setup(m => m.Delete(resultValue.Id))
                                    .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var resultDel = await _controller.Delete(resultValue.Id);
            Assert.True(resultDel is NoContentResult);
        }
    }
}