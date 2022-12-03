namespace GalaxyApp.Entidades;

public class TallerAlumno : EntityBase
{
    public Taller Taller { get; set; } = default!;
    public int TallerId { get; set; }
    public Alumno Alumno { get; set; } = default!;
    public int AlumnoId { get; set; }
    public DateTime FechaInscripcion { get; set; }

    public InscripcionEnum InscripcionEnum { get; set; }
    
}