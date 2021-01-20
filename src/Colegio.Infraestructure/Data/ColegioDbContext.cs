using Colegio.Domain.Entities;
using Colegio.Infraestructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Colegio.Domain.Data
{
    public class ColegioDbContext : DbContext
    {
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options)
        {

        }

        public DbSet<ProfesorEntity> Profesores { get; set; }
        public DbSet<AsignaturaEntity> Asignaturas { get; set; }
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<ProfesorAsignaturaEntity> ProfesorAsignaturas { get; set; }
        public DbSet<AlumnoAsignaturaEntity> AlumnoAsignaturas { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Establecer Esquema por defecto de la Base de datos
            modelBuilder.HasDefaultSchema("Colegio");

            // Cargar Configuracion de tablas manera automatica
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColegioDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }



    }
}
