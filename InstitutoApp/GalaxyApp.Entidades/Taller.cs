namespace GalaxyApp.Entidades;

public class Taller : EntityBase
{
    public string Nombre { get; set; } = default!;

    public DateTime FechaInicio { get; set; }

    public SituacionEnum Situacion { get; set; }

    public string? PortadaUrl { get; set; }
    public string? TemarioUrl { get; set; }

    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; } = default!;

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = default!;

    public ICollection<Tema> Temas { get; set; } = default!;
}