using System;
using System.Threading.Tasks;

using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;

using Moq;

using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGet: UfTestes
    {
        private IUfService service;
        private Mock<IUfService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método Get.")]
        public async Task Eh_PossivelExecutarMetodoGet()
        {
            this.serviceMock = new Mock<IUfService>();
            this.serviceMock.Setup(m => m.Get(IdUf)).ReturnsAsync(UfDto);
            this.service = this.serviceMock.Object;
            var result = await this.service.Get(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(Nome, result.Nome);

            this.serviceMock = new Mock<IUfService>();
            this.serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(Task.FromResult((UfDto)null));
            this.service = serviceMock.Object;
            var recod = await this.service.Get(IdUf);
            Assert.Null(recod);
        }
    }
}
