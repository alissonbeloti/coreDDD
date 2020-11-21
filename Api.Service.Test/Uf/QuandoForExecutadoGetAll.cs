using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Domain.Interfaces.Services.User;
using Api.Service.Test.Usuario;

using Domain.Dtos.Uf;
using Domain.Interfaces.Services.Uf;

using Moq;

using Xunit;

namespace Api.Service.Test.Uf
{
    public class QuandoForExecutadoGetAll: UfTestes
    {
        private IUfService service;
        private Mock<IUfService> serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método GetAll.")]
        public async Task Eh_Possivel_Executar_GetAll()
        {
            this.serviceMock = new Mock<IUfService>();
            this.serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ufDtos);
            this.service = this.serviceMock.Object;
            var result = await this.service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 11);

            var listResult = new List<UfDto>();
            this.serviceMock = new Mock<IUfService>();
            this.serviceMock.Setup(m => m.GetAll())
                .ReturnsAsync(listResult.AsEnumerable());
            this.service = serviceMock.Object;
            var resultEmpty = await this.service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
