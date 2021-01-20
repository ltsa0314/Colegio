using Colegio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Infraestructure.Configurations
{
    public class AsignaturaConfiguration: IEntityTypeConfiguration<AsignaturaEntity>
    {
        public void Configure(EntityTypeBuilder<AsignaturaEntity> builder)
        {
            builder.ToTable("Asignatura");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(200);

        }
    }
}
