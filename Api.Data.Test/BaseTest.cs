using System;

using Api.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Api.Data.Test
{
    public class BaseTest
    {
        public BaseTest()
        {

        }
    }
    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(
                o => o.UseSqlServer($"Data Source=DESKTOP-ROLELGP\\SQLEXPRESS;Initial Catalog={dataBaseName};User Id=sa;pwd=9a7pd!@simco;Connect Timeout=30;MultipleActiveResultSets=true;"),
                ServiceLifetime.Transient
                );
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using(var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
