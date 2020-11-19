using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.User;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Application.Test.Usuario.QunadoRequisitarGet
{
    public class Retorno_GetAll
    {
        private UsersController controller;
        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task Eh_Possivel_Invocar_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>()
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow,
                    },
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow,
                    }
                });
            this.controller = new UsersController(serviceMock.Object);
            var result = await this.controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<UserDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count == 2);
           
        }
    }
}
