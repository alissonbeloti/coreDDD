using System;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.Municipio;
using Domain.Dtos.User;
using Domain.Interfaces.Services.Municipio;

using Moq;

using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGet: MunicipioTestes
    {
        private IMunicipioService service;
        private Mock<IMunicipioService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método Get.")]
        public async Task Eh_PossivelExecutarMetodoGet()
        {
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.Get(IdMunicipio)).ReturnsAsync(this.MunicipioDto);
            this.service = this.serviceMock.Object;
            var result = await this.service.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIbgeMunicipio, result.CodIbge);

            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(Task.FromResult((MunicipioDto)null));
            this.service = serviceMock.Object;
            var record = await this.service.Get(IdMunicipio);
            Assert.Null(record);
        }
    }
}
