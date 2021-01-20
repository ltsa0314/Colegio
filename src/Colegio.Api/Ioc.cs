using Colegio.Domain.Data;
using Colegio.Domain.Repositories.Implementations;
using Colegio.Domain.Repositories.Interfaces;
using Colegio.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Colegio.Api
{
    /// <summary>
    /// Inversion of control (Invercion de control)
    /// </summary>
    public class Ioc
    {

        public static IServiceCollection AddDbContext(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<ColegioDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ColegioDb")));
            services.AddDbContext<ColegioQuerysDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ColegioDb")));
            return services;
        }
        public static IServiceCollection AddSwagger(IServiceCollection services)
        {
            // Swagger
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var xmlPath = Path.Combine(basePath, "Colegio.Api.xml");

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Colegio Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "ltsa0314@gmail.com",
                        Name = "Leidy Tatiana Sanchez ",
                    },
                });

                config.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IServiceCollection AddRepositories(IServiceCollection services)
        {
            // Transient , Scope , Singleton---- se resulven las instancias de los repositories
            services.AddTransient<IProfesorRepository, ProfesorRepository>();
            services.AddTransient<IAlumnoRepository, AlumnoRepository>();
            services.AddTransient<IAsignaturaRepository, AsignaturaRepository>();
            services.AddTransient<IProfesorAsignaturaRepository, ProfesorAsignaturaRepository>();
            services.AddTransient<IAlumnoAsignaturaRepository, AlumnoAsignaturaRepository>();

            return services;
        }
    }
}
