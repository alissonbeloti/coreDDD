using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Api.Application.Test.Uf.QunadoRequisitarGetAll
{
    public class Retorno_Get
    {
        private UfsController controller;
        [Fact(DisplayName ="É possível Realizar o Get.")]
        public async Task Eh_Possivel_Invocar_Controller_GetAll()
        {
            var serviceMock = new Mock<IUfService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UfDto> {
                new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                },
                new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Amazonas",
                    Sigla = "AM"
                },
            });

            this.controller = new UfsController(serviceMock.Object);

            var result = await this.controller.GetAll();
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UfDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
