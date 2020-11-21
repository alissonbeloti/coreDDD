using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Domain.Entities;

using Data.Implementations;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Api.Data.Test
{
    public class UfsGets : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider serviceProvider;

        public UfsGets(DbTeste dbTeste)
        {
            this.serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Get de UF")]
        [Trait("Gets", "UfEntity")]
        public async Task E_Possivel_Realizar_Gets_Uf()
        {
            using (var context = serviceProvider.GetService<MyContext>())
            {
                UfImplementation repositorio = new UfImplementation(context);
                UfEntity entity = new UfEntity
                {
                    Id = new Guid("8F259D7F-A503-40E6-9FA3-3FE156047123"),
                    Sigla = "SP",
                    Nome = "São Paulo"
                };

                var registroExiste = await repositorio.ExistAsync(entity.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await repositorio.SelectAsync(entity.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(entity.Sigla, registroSelecionado.Sigla);
                Assert.Equal(entity.Nome, registroSelecionado.Nome);

                var todosRegistros = await repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 1);

            }
        }
    }
}
