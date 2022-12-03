using GalaxyApp.Dto.Request;
using GalaxyApp.Dto.Response;

namespace GalaxyApp.Servicios;

public interface IUsuarioService
{
    Task<BaseResponseGeneric<string>> RegistrarUsuario(RegistrarUsuarioRequest request);

    Task<LoginResponseDto> Login(LoginRequest request);
}