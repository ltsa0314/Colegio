using Colegio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Infraestructure.Data
{
    public class ColegioQuerysDbContext : DbContext
    {
        public DbSet<ReporteCalificacionesEntity> ReporteCalificaciones { get; set; }

        public ColegioQuerysDbContext(DbContextOptions<ColegioQuerysDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Establecer Esquema por defecto de la Base de datos
            modelBuilder.Entity<ReporteCalificacionesEntity>(x =>
            {
                x.HasNoKey();
                x.ToQuery(() => ReporteCalificaciones.FromSqlRaw(@"SELECT AA.Ano, IdentificacionAlumno= A.Identificacion, NombreAlumno=A.Nombre, CodigoMateria=AST.Codigo ,NombreMateria= AST.Nombre ,IdentificacionProfesor= P.Identificacion, NombreProfesor= P.Nombre, AA.CalificacionFinal,
                                                    Aprobo = CASE WHEN AA.CalificacionFinal >= 3 THEN 'SI' ELSE 'NO' END
                                                    from Colegio.Alumno A
                                                    INNER JOIN Colegio.AlumnoAsignatura AA on AA.AlumnoId = a.Id
                                                    INNER JOIN Colegio.Asignatura AST ON AST.Id = AA.AsignaturaId
                                                    INNER JOIN Colegio.ProfesorAsignatura PA ON PA.AsignaturaId = AST.Id
                                                    INNER JOIN Colegio.Profesor P ON P.Id = PA.ProfesorId"))
                ;
            });
            base.OnModelCreating(modelBuilder);


        }

    }
}
