﻿using System;
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
    public class Retorno_Created
    {
        private UsersController controller;
        [Fact(DisplayName ="É possível Realizar o Created.")]
        public async Task Eh_Possivel_Invocar_Controller_Create()
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
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5000");
            this.controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate { 
                Name = nome,
                Email = email,
            };

            var result = await this.controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);
        }
    }
}
