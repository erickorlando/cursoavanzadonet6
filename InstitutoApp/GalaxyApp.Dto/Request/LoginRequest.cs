namespace GalaxyApp.Dto.Request;

public class LoginRequest
{
    public string Usuario { get; set; } = default!;
    public string Password { get; set; } = default!;
}