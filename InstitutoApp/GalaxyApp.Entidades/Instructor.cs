using System.Xml.Serialization;

namespace GalaxyApp.Entidades;

public class Instructor : EntityBase
{
    public string Nombres { get; set; } = default!;
    public string Apellidos { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Celular { get; set; } = default!;
    public string Dni { get; set; } = default!;
    public Categoria Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }

}