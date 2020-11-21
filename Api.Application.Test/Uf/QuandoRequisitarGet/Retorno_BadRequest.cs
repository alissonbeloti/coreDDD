using System;
using System.Threading.Tasks;

using Api.Application.Controllers;

using application.Controllers;

using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace Api.Application.Test.Uf.QunadoRequisitarGet
{
    public class Retorno_Get_BadRequest_Uf
    {
        private UfsController controller;
        [Fact(DisplayName ="Testa erro de badRequest.")]
        public async Task Eh_Possivel_Invocar_Controller_Get_badrequest()
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
            this.controller.ModelState.TryAddModelError("Id", "Formato Inválido.");

            var result = await this.controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
