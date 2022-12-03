namespace GalaxyApp.Entidades;

public class EntityBase
{
    public int Id { get; set; }


    // Campos de Auditoria
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }
    public bool Estado { get; set; }

    protected EntityBase()
    {
        FechaCreacion = DateTime.Now;
        Estado = true;
    }
}