using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.AccesoDatos;

public class GalaxyUser : IdentityUser
{
    [StringLength(200)]
    public string NombresCompletos { get; set; } = default!;

    [StringLength(11)]
    public string NroDocumento { get; set; } = default!;
}