using GalaxyApp.Dto.Request;
using GalaxyApp.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(RegistrarUsuarioRequest request)
        {
            var response = await _service.RegistrarUsuario(request);

            if (response.Exito)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
