using System;
using System.Threading.Tasks;

using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.User;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Application.Test.Usuario.QunadoRequisitarDelete
{
    public class Retorno_Deleted
    {
        private UsersController controller;
        [Fact(DisplayName ="É possível Realizar o Deleted.")]
        public async Task Eh_Possivel_Invocar_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(
                true);
            this.controller = new UsersController(serviceMock.Object);
            
            var result = await this.controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
