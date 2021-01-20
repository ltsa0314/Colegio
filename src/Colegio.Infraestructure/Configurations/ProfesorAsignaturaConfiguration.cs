using Colegio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Infraestructure.Configurations
{
    public class ProfesorAsignaturaConfiguration : IEntityTypeConfiguration<ProfesorAsignaturaEntity>
    {
        public void Configure(EntityTypeBuilder<ProfesorAsignaturaEntity> builder)
        {
            builder.ToTable("ProfesorAsignatura");
            builder.HasKey(x => x.ProfesorId);
            builder.Property(x => x.ProfesorId).IsRequired();
            builder.Property(x => x.AsignaturaId).IsRequired();

        }
    }
}
