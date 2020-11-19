using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Moq;

using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate: UsuarioTestes
    {
        private IUserService service;
        private Mock<IUserService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update.")]
        public async Task Eh_Possivel_Executar_Update()
        {
            //Create
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.Post(UserDtoCreate))
                .ReturnsAsync(UserDtoCreateResult);
            this.service = this.serviceMock.Object;

            var result = await this.service.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
            //Update
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.Put(UserDtoUpdate))
                .ReturnsAsync(UserDtoUpdateResult);
            this.service = this.serviceMock.Object;

            var resultAlt = await this.service.Put(UserDtoUpdate);
            Assert.NotNull(resultAlt);
            Assert.Equal(NomeUsuarioAlterado, resultAlt.Name);
            Assert.Equal(EmailUsuarioAlterado, resultAlt.Email);
        }
    }
}
