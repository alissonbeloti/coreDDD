using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;

using Domain.Interfaces.Services.Cep;
using Domain.Interfaces.Services.Municipio;
using Domain.Interfaces.Services.Uf;

using Microsoft.Extensions.DependencyInjection;

using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfServices>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioServices>();
            serviceCollection.AddTransient<ICepService, CepServices>();
        }
    }
}
