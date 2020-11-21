using System.Threading.Tasks;

using Domain.Interfaces.Services.Municipio;

using Moq;

using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoUpdate : MunicipioTestes
    {
        private IMunicipioService service;
        private Mock<IMunicipioService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update.")]
        public async Task Eh_Possivel_Executar_Update()
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
    
               
            //Update
            this.serviceMock = new Mock<IMunicipioService>();
            this.serviceMock.Setup(m => m.Put(MunicipioDtoUpdate))
                .ReturnsAsync(MunicipioDtoUpdateResult);
            this.service = this.serviceMock.Object;

            var resultAlt = await this.service.Put(MunicipioDtoUpdate);
            Assert.NotNull(resultAlt);
            Assert.Equal(NomeMunicipioAlterado, resultAlt.Nome);
            Assert.Equal(CodigoIbgeMunicipioAlterado, resultAlt.CodIbge);
            
        }
    }
}
