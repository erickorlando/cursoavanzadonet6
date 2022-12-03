namespace GalaxyApp.Dto.Response;

public class LoginResponseDto : BaseResponse
{
    public string NombresCompletos { get; set; } = default!;
    public string Token { get; set; } = default!;
}