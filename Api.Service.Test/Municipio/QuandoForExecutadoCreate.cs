using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Interfaces.Services.Municipio;

using Moq;

using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoCreate: MunicipioTestes
    {
        private IMunicipioService service;
        private Mock<IMunicipioService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create.")]
        public async Task Eh_Possivel_Executar_Create()
        {
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.Post(MunicipioDtoCreate))
                .ReturnsAsync(MunicipioDtoCreateResult);
            this.service = this.serviceMock.Object;

            var result = await this.service.Post(MunicipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIbgeMunicipio, result.CodIbge);
            Assert.Equal(IdUf, result.UfId);
        }
    }
}
