namespace GalaxyApp.Entidades.Infos;

public class TallerInfo
{
    public int IdTaller { get; set; }
    public string Nombre { get; set; } = default!;
    public string FechaInicio { get; set; } = default!;
    public string Situacion { get; set; } = default!;

    public string? PortadaUrl { get; set; }

    public string Instructor { get; set; } = default!;
    public string Categoria { get; set; } = default!;

}