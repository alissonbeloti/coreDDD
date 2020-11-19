using System;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Moq;

using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete: UsuarioTestes
    {
        private IUserService service;
        private Mock<IUserService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task Eh_PossivelExecutarMetodoDelete()
        {
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            this.service = this.serviceMock.Object;
            var deletado = await this.service.Delete(IdUsuario);
            Assert.True(deletado);
        }
    }
}
