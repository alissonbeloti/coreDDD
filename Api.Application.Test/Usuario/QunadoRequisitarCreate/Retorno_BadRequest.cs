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

namespace Api.Application.Test.Usuario.QunadoRequisitarCreate
{
    public class Retorno_BadRequest
    {
        private UsersController controller;
        [Fact(DisplayName ="Testa erro de badRequest.")]
        public async Task Eh_Possivel_Invocar_Controller_Create_badrequest()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult()
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });
            this.controller = new UsersController(serviceMock.Object);
            this.controller.ModelState.TryAddModelError("Name", "É um campo obrigatório");
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5000");
            this.controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate { 
                Name = nome,
                Email = email,
            };

            var result = await this.controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
