using System;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.User;

using Moq;

using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet: UsuarioTestes
    {
        private IUserService service;
        private Mock<IUserService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método Get.")]
        public async Task Eh_PossivelExecutarMetodoGet()
        {
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(this.UserDto);
            this.service = this.serviceMock.Object;
            var result = await this.service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(Task.FromResult((UserDto)null));
            this.service = serviceMock.Object;
            var recod = await this.service.Get(IdUsuario);
            Assert.Null(recod);
        }
    }
}
