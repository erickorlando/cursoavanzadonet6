using GalaxyApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.AccesoDatos.Configurations;

public class TallerConfiguration : IEntityTypeConfiguration<Taller>
{
    public void Configure(EntityTypeBuilder<Taller> builder)
    {
        builder.ToTable("Talleres");
        builder.Property(t => t.Nombre)
            .HasMaxLength(100);
        builder.Property(t => t.FechaInicio)
            .HasColumnType("datetime2");

        builder.Property(t => t.PortadaUrl)
            .IsUnicode(false) // varchar en lugar de nvarchar
            .HasMaxLength(500);

        builder.Property(t => t.TemarioUrl)
            .IsUnicode(false)
            .HasMaxLength(500);

        builder.Property(p => p.Situacion)
            .HasConversion<short>();

        builder.HasMany(p => p.Temas)
            .WithOne(p => p.Taller)
            .HasForeignKey(p => p.TallerId);

    }
}