using Colegio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Infraestructure.Configurations
{
    public class AlumnoConfiguration:  IEntityTypeConfiguration<AlumnoEntity>
    {


        public  void Configure(EntityTypeBuilder<AlumnoEntity> builder)
        {
            builder.ToTable("Alumno");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Identificacion).IsRequired().HasMaxLength(21);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Direccion).HasMaxLength(500);
        }
    }
}
