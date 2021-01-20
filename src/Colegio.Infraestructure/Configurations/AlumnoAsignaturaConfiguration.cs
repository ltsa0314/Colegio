using Colegio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Infraestructure.Configurations
{
    public class AlumnoAsignaturaConfiguration :IEntityTypeConfiguration<AlumnoAsignaturaEntity>
    {
        public  void Configure(EntityTypeBuilder<AlumnoAsignaturaEntity> builder)
        {
            builder.ToTable("AlumnoAsignatura");
            builder.HasKey(x => new { x.AlumnoId, x.AsignaturaId, x.Ano });
            builder.Property(x => x.AlumnoId).IsRequired();
            builder.Property(x => x.AsignaturaId).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.CalificacionFinal).IsRequired();
        }
    }
}
