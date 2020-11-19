using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Domain.Dtos.User;

using Newtonsoft.Json;

using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario: BaseIntegration
    {
        private string name;
        private string email;

        [Fact]
        public async Task Eh_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();
            name = Faker.Name.First();
            email = Faker.Internet.Email();

            var userDto = new UserDtoCreate
            {
                Name = name,
                Email = email,
            };

            ///Post
            var response = await PostJsonAsync(userDto, $"{this.HostApi}users", this.Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(name, registroPost.Name);
            Assert.Equal(email, registroPost.Email);
            Assert.True(registroPost.Id != default(Guid));

            ///Get All
            response = await this.Client.GetAsync($"{this.HostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Any());


            var userDtoUpdate = new UserDtoUpdate
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            ///Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDtoUpdate), Encoding.UTF8, "application/json");
            response = await this.Client.PutAsync($"{this.HostApi}users", stringContent);
            var putResult = await response.Content.ReadAsStringAsync();
            var registroPut = JsonConvert.DeserializeObject<UserDtoUpdateResult>(putResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(name, registroPut.Name);
            Assert.NotEqual(email, registroPut.Email);

            ///Get Id
            response = await this.Client.GetAsync($"{this.HostApi}users/{registroPut.Id}");
            var getResult = await response.Content.ReadAsStringAsync();
            var registroGet = JsonConvert.DeserializeObject<UserDto>(getResult);
            Assert.NotNull(registroGet);
            Assert.NotEqual(name, registroGet.Name);
            Assert.NotEqual(email, registroGet.Email);

            ///delete
            response = await this.Client.DeleteAsync($"{this.HostApi}users/{registroPut.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //response = await this.Client.DeleteAsync($"{this.HostApi}users/{registroPut.Id}");
            //Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
