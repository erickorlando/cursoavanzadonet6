namespace GalaxyApp.Dto.Request;

public class RequestTallerBusqueda: PaginacionRequest
{
    public string? Nombre { get; init; } 
    public int? CategoriaId { get; init; }
    public int? Situacion { get; init; } 
}