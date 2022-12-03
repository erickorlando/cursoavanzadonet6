using System.ComponentModel.DataAnnotations;

namespace GalaxyApp.Entidades;

public class Tema
{
    public int Id { get; set; }
    public Taller Taller { get; set; } = default!;
    public int TallerId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = default!;
}