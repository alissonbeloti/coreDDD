using System;
using System.Threading.Tasks;

using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;

using Moq;

using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService service;
        private Mock<ILoginService> serviceMock;

        [Fact(DisplayName = "É possível Executar o Método FindByLogin.")]
        public async Task Eh_PossivelExecutarMetodoFindByLogin()
        {
            var email = Faker.Internet.Email();
            var objetoRetorno = new
            {
                authenticated = true,
                crate = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            this.serviceMock = new Mock<ILoginService>();
            this.serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            this.service = this.serviceMock.Object;
            var result = await this.service.FindByLogin(loginDto);
            Assert.NotNull(result);
            
        }
    }
}
