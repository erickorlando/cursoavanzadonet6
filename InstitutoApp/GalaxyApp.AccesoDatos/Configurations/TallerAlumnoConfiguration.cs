using GalaxyApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.AccesoDatos.Configurations;

public class TallerAlumnoConfiguration : IEntityTypeConfiguration<TallerAlumno>
{
    public void Configure(EntityTypeBuilder<TallerAlumno> builder)
    {
        builder.ToTable("TallerAlumno");
        
        builder.Property(ta => ta.FechaInscripcion)
            .HasColumnType("DATE")
            .HasDefaultValueSql("getdate()");

        builder.Property(p => p.InscripcionEnum)
            .HasConversion<short>();
    }
}