using System;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Interfaces.Services.Municipio;

using Moq;

using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoDelete: MunicipioTestes
    {
        private IMunicipioService service;
        private Mock<IMunicipioService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task Eh_PossivelExecutarMetodoDelete()
        {
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            this.service = this.serviceMock.Object;
            var deletado = await this.service.Delete(IdMunicipio);
            Assert.True(deletado);
        }
    }
}
