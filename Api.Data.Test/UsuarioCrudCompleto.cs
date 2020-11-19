using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto: BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            this.serviceProvider = dbTeste.ServiceProvider;
        }
        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_User()
        {
            using (var context = this.serviceProvider.GetService<MyContext>())
            {
                UserImplementation repositorio = new UserImplementation(context);
                UserEntity entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName(),
                };
                var registroCriado = await repositorio.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.Email, registroCriado.Email);
                Assert.Equal(entity.Name, registroCriado.Name);
                Assert.False(registroCriado.Id == Guid.Empty);

                entity.Name = Faker.Name.First();
                var registroAtualizado = await repositorio.UpdateAsync(entity);
                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.Email, registroAtualizado.Email);
                Assert.Equal(entity.Name, registroAtualizado.Name);

                var registroExiste = await repositorio.ExistAsync(registroCriado.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await repositorio.SelectAsync(registroCriado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.Email, registroSelecionado.Email);
                Assert.Equal(registroAtualizado.Name, registroSelecionado.Name);

                var todosRegistros = await repositorio.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 1);

                var removeu = await repositorio.DeleteAsync(registroSelecionado.Id);
                Assert.True(removeu);

                var usuarioPadrao = await repositorio.FindByLogin("alisson@email.com");
                Assert.NotNull(usuarioPadrao);
                Assert.Equal("Administrador", usuarioPadrao.Name);
            }
        }
    }
}
