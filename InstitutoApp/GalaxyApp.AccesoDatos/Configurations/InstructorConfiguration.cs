using GalaxyApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.AccesoDatos.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructores");
        
        builder.Property(i => i.Nombres)
            .HasMaxLength(100);
        builder.Property(i => i.Apellidos)
            .HasMaxLength(100);
        builder.Property(i => i.Email)
            .HasMaxLength(500);
        builder.Property(i => i.Celular)
            .HasMaxLength(20);
        builder.Property(i => i.Dni)
            .HasMaxLength(11);
        
    }
}