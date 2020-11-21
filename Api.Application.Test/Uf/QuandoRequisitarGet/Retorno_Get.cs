using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;

using application.Controllers;

using Domain.Dtos.Uf;
using Domain.Dtos.User;
using Domain.Interfaces.Services.Uf;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Application.Test.Uf.QunadoRequisitarGet
{
    public class Retorno_Get_Uf
    {
        private UfsController controller;
        [Fact(DisplayName ="É possível Realizar o Get.")]
        public async Task Eh_Possivel_Invocar_Controller_Get()
        {
            var serviceMock = new Mock<IUfService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                });
            this.controller = new UfsController(serviceMock.Object);
            var result = await this.controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UfDto;
            Assert.NotNull(resultValue);
        }
    }
}
