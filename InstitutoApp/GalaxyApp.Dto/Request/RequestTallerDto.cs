namespace GalaxyApp.Dto.Request;

public class RequestTallerDto
{
    public string Nombre { get; set; } = default!;
    public int CategoriaId { get; set; } 
    public RequestInstructorDto RequestInstructorDto { get; set; } = default!;
    public string FechaInicio { get; set; } = default!;
    public string HoraInicio { get; set; } = default!;
    public short Situacion { get; set; }
    public string? PortadaBase64 { get; set; }
    public string? ArchivoPortada { get; set; }
    public string? TemarioBase64 { get; set; }
    public string? ArchivoTemario { get; set; }
    public ICollection<RequestTemaDto> Temas { get; set; } = default!;
}

public class RequestTemaDto
{
    public string NombreTema { get; set; } = default!;
}
    
public class RequestInstructorDto
{
    public int? IdInstructor { get; set; }
    public string Nombres { get; set; } = default!;
    public string Apellidos { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Celular { get; set; } = default!;
    public string Dni { get; set; } = default!;
}