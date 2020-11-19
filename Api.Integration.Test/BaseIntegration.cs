using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Api.Data.Context;
using Api.Domain.Dtos;

using application;

using AutoMapper;

using CrossCutting.Mappings;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public class BaseIntegration: IDisposable
    {
        public MyContext MyContext { get; set; }
        public HttpClient Client { get; private set; }
        public IMapper Mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage Response { get; set; }
        public BaseIntegration()
        {
            this.HostApi = "http://localhost:37923/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();
            var server = new TestServer(builder);
            this.MyContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            MyContext.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();
            Client = server.CreateClient();
        }
        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto
            {
                Email = "alisson@email.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{this.HostApi}login", Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, 
                //new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json")
                new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8)
                );
        }
        public void Dispose()
        {
            this.MyContext.Dispose();
            Client.Dispose();
        }
    }
    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
            return config.CreateMapper();
        }
        public void Dispose()
        {
        }
    }
}
