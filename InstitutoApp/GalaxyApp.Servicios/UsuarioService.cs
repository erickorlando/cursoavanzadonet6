using GalaxyApp.AccesoDatos;
using GalaxyApp.Dto.Request;
using GalaxyApp.Dto.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Text;

namespace GalaxyApp.Servicios;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<GalaxyUser> _userManager;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(UserManager<GalaxyUser> userManager, ILogger<UsuarioService> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<BaseResponseGeneric<string>> RegistrarUsuario(RegistrarUsuarioRequest request)
    {
        var response = new BaseResponseGeneric<string>();

        try
        {
            var usuario = new GalaxyUser
            {
                UserName = request.NombreUsuario,
                Email = request.Correo,
                NombresCompletos = request.Nombres,
                NroDocumento = request.Dni,
                PhoneNumber = request.Telefono
            };

            var resultado = await _userManager.CreateAsync(usuario, request.Password);

            if (resultado.Succeeded)
            {
                _logger.LogInformation("Usuario creado satisfactoriamente");
                response.Data = usuario.Id;
                response.Exito = true;
            }
            else
            {
                _logger.LogError("Error al crear el usuario");
                var sb = new StringBuilder();
                foreach (var itemError in resultado.Errors)
                {
                    sb.AppendLine(itemError.Description);
                }
                response.MensajeError = sb.ToString();
                sb.Length = 0;

                response.Exito = false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el usuario {Message}", ex.Message);
            response.MensajeError = ex.Message;
        }

        return response;
    }

    public Task<LoginResponseDto> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}