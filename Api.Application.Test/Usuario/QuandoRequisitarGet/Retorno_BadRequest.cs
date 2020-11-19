using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.User;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Application.Test.Usuario.QunadoRequisitarGet
{
    public class Retorno_Get_BadRequest
    {
        private UsersController controller;
        [Fact(DisplayName ="Testa erro de badRequest.")]
        public async Task Eh_Possivel_Invocar_Controller_Get_badrequest()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });
            this.controller = new UsersController(serviceMock.Object);
            this.controller.ModelState.TryAddModelError("Id", "Formato Inválido.");

            var result = await this.controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
