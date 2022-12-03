namespace GalaxyApp.Entidades;

public class Alumno : EntityBase
{
    public string NombresCompletos { get; set; } = default!;
    public string Dni { get; set; } = default!;
    public string CorreoElectronico { get; set; } = default!;
}