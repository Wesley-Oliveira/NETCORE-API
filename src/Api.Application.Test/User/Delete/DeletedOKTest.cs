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

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                                    .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean) resultValue);

            //Adicionar tratamento comparando se guid existe ou não e comparar a partir disto
            //Caso contrário, este teste irá falhar
        }
    }
}