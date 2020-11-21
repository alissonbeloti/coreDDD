using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.Municipio;
using Domain.Dtos.User;
using Domain.Interfaces.Services.Municipio;

using Moq;

using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetAll: MunicipioTestes
    {
        private IMunicipioService service;
        private Mock<IMunicipioService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método GetAll.")]
        public async Task Eh_Possivel_Executar_GetAll()
        {
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.GetCompleteByUf(IdUf)).ReturnsAsync(municipioDtos);
            this.service = this.serviceMock.Object;
            var result = await this.service.GetCompleteByUf(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<MunicipioDtoCompleto>();
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.GetCompleteByUf(Guid.NewGuid()))
                .ReturnsAsync(listResult.AsEnumerable());
            this.service = serviceMock.Object;
            var resultEmpty = await this.service.GetCompleteByUf(IdUf);
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
