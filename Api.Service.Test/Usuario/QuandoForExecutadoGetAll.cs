using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;

using Domain.Dtos.User;

using Moq;

using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll: UsuarioTestes
    {
        private IUserService service;
        private Mock<IUserService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método GetAll.")]
        public async Task Eh_Possivel_Executar_GetAll()
        {
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userDtos);
            this.service = this.serviceMock.Object;
            var result = await this.service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<UserDto>();
            this.serviceMock = new Mock<IUserService>();
            this.serviceMock.Setup(m => m.GetAll())
                .ReturnsAsync(listResult.AsEnumerable());
            this.service = serviceMock.Object;
            var resultEmpty = await this.service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
