using System;
using System.Linq;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Domain.Entities;

using Data.Implementations;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Api.Data.Test
{
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider serviceProvider;

        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            this.serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = this.serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation repositorio = new MunicipioImplementation(context);
                MunicipioEntity entity = new MunicipioEntity
                {
                    CodIbge = Faker.RandomNumber.Next(1000000, 9999999),
                    Nome = Faker.Address.City(),
                    UfId = new Guid("8F259D7F-A503-40E6-9FA3-3FE156047123")
                };
                var registroCriado = await repositorio.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.Nome, registroCriado.Nome);
                Assert.Equal(entity.CodIbge, registroCriado.CodIbge);
                Assert.False(registroCriado.Id == Guid.Empty);

                entity.Nome = Faker.Address.City();
                entity.Id = registroCriado.Id;
                var registroAtualizado = await repositorio.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.CodIbge, registroAtualizado.CodIbge);
                Assert.Equal(entity.Nome, registroAtualizado.Nome);
                Assert.Equal(entity.UfId, registroAtualizado.UfId);

                var registroExiste = await repositorio.ExistAsync(registroCriado.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await repositorio.SelectAsync(registroCriado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.CodIbge, registroSelecionado.CodIbge);
                Assert.Equal(registroAtualizado.Nome, registroSelecionado.Nome);
                Assert.Equal(registroAtualizado.UfId, registroSelecionado.UfId);
                Assert.Null(registroAtualizado.Uf);

                var todosRegistros = await repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 0);

                var municipioIbge = await repositorio.GetMunicipioByIbge(registroAtualizado.CodIbge);
                Assert.NotNull(municipioIbge);
                Assert.Equal(municipioIbge.CodIbge, registroAtualizado.CodIbge);
                Assert.Equal(registroAtualizado.Nome, municipioIbge.Nome);
                Assert.NotNull(municipioIbge.Uf);

                var removeu = await repositorio.DeleteAsync(registroSelecionado.Id);
                Assert.True(removeu);

            }
        }
    }
}
