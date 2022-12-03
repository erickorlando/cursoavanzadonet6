using GalaxyApp.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalaxyApp.AccesoDatos.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.Property(c => c.Nombre)
            .HasMaxLength(100);


        builder.HasData(new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Java" },
            new Categoria { Id = 2, Nombre = ".NET" },
            new Categoria { Id = 3, Nombre = "Azure" },
            new Categoria { Id = 4, Nombre = "AWS" },
            new Categoria { Id = 5, Nombre = "Microservicios .NET" },
            new Categoria { Id = 6, Nombre = "Microservicios Java" },
            new Categoria { Id = 7, Nombre = "Frontend Angular" },
            new Categoria { Id = 8, Nombre = "React" },
        });
    }
}
