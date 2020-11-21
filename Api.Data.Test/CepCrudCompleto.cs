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
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider serviceProvider;

        public CepCrudCompleto(DbTeste dbTeste)
        {
            this.serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = this.serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity entityMunicipio = new MunicipioEntity
                {
                    CodIbge = Faker.RandomNumber.Next(1000000, 9999999),
                    Nome = Faker.Address.City(),
                    UfId = new Guid("8F259D7F-A503-40E6-9FA3-3FE156047123")
                };
                var registroCriadoMunicipio = await repositorioMunicipio.InsertAsync(entityMunicipio);
                Assert.NotNull(registroCriadoMunicipio);
                Assert.Equal(entityMunicipio.Nome, registroCriadoMunicipio.Nome);
                Assert.Equal(entityMunicipio.CodIbge, registroCriadoMunicipio.CodIbge);
                Assert.False(registroCriadoMunicipio.Id == Guid.Empty);

                CepImplementation repositorio = new CepImplementation(context);
                CepEntity entity = new CepEntity
                {
                    Cep = "15.358-000",
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = "0 até 1500", 
                    MunicipioId = registroCriadoMunicipio.Id
                };
                
                var registroCriado = await repositorio.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.Cep, registroCriado.Cep);
                Assert.Equal(entity.Logradouro, registroCriado.Logradouro);
                Assert.Equal(entity.Numero, registroCriado.Numero);
                Assert.False(registroCriado.Id == Guid.Empty);

                entity.Logradouro = Faker.Address.StreetName();
                entity.Id = registroCriado.Id;
                entity.Numero = "1000-2000";
                var registroAtualizado = await repositorio.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.Cep, registroAtualizado.Cep);
                Assert.Equal(entity.Logradouro, registroAtualizado.Logradouro);
                Assert.Equal(entity.Numero, registroAtualizado.Numero);

                var registroExiste = await repositorio.ExistAsync(registroCriado.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await repositorio.SelectAsync(registroCriado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.Cep, registroSelecionado.Cep);
                Assert.Equal(registroAtualizado.Logradouro, registroSelecionado.Logradouro);
                Assert.Equal(registroAtualizado.Numero, registroSelecionado.Numero);
                Assert.NotNull(registroAtualizado.Municipio);
                Assert.Null(registroAtualizado.Municipio.Uf);

                var todosRegistros = await repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 0);

                var cepPorCep = await repositorio.SelectAsync(registroAtualizado.Cep);
                Assert.NotNull(cepPorCep);
                Assert.Equal(cepPorCep.Logradouro, registroAtualizado.Logradouro);
                Assert.Equal(registroAtualizado.Numero, cepPorCep.Numero);
                Assert.NotNull(cepPorCep.Municipio);
                Assert.NotNull(cepPorCep.Municipio.Uf);

                var ceps = await repositorio.SelectLogradouroAsync(registroAtualizado.Logradouro);
                Assert.NotNull(ceps);
                Assert.True(ceps.Any());
                
            }
        }
    }
}
