using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //var connectionString = "Server=localhost;Port=3306;DataBase=dbAPI;Uid=root;Pwd=root";
            var connectionString = @"Data Source=DESKTOP-ROLELGP\SQLEXPRESS;Initial Catalog=dbAPI;User Id=sa;pwd=9a7pd!@simco;Connect Timeout=30;MultipleActiveResultSets=true;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
