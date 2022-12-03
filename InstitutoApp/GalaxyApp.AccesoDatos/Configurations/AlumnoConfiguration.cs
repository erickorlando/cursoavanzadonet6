using GalaxyApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.AccesoDatos.Configurations;

public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable("Alumnos");
        builder.Property(a => a.NombresCompletos)
            .HasMaxLength(100);
        builder.Property(a => a.Dni)
            .HasMaxLength(11);
        builder.Property(a => a.CorreoElectronico)
            .HasMaxLength(500);
    }
}