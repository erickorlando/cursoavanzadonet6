using System.ComponentModel.DataAnnotations;

namespace GalaxyApp.Dto.Request;

public class RegistrarUsuarioRequest
{
    [Required]
    public string NombreUsuario { get; set; } = default!;
    
    public string Nombres { get; set; } = default!;
    public string Dni { get; set; } = default!;

    [EmailAddress]
    public string Correo { get; set; } = default!;
    
    public string Telefono { get; set; } = default!;
    
    public string Password { get; set; } = default!;

    [Compare(nameof(Password))]
    public string ConfirmarPassword { get; set; } = default!;
}