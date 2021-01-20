using Colegio.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Colegio.Infraestructure.Data
{
    public class ColegioDbContextFactory : IDesignTimeDbContextFactory<ColegioDbContext>
    {
        public ColegioDbContext CreateDbContext(string[] args)
        {
            // Configurar el Contexto para la migraciones desde el proyecto Infraestructure
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddEnvironmentVariables();


            var config = builder.Build();
            var conectionString = config.GetSection("ConnectionStrings:ColegioDb").Value;
            var optionsBuilder = new DbContextOptionsBuilder<ColegioDbContext>();

            var options = optionsBuilder.UseSqlServer(conectionString).UseLazyLoadingProxies().Options;

            return new ColegioDbContext(options);
        }
    }
}
