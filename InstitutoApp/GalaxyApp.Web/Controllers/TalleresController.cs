using GalaxyApp.Dto.Request;
using GalaxyApp.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleresController : ControllerBase
    {
        private readonly ITallerService _service;

        public TalleresController(ITallerService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Listar(string? nombre, int? categoriaId, int? situacion, int pagina = 1,
            int filas = 5)
        {
            return Ok(await _service.Listar(new RequestTallerBusqueda
            {
                Nombre = nombre,
                CategoriaId = categoriaId,
                Situacion = situacion,
                Pagina = pagina,
                Filas = filas
            }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            return Ok(await _service.Obtener(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]RequestTallerDto request)
        {
            var response = await _service.Crear(request);
            return response.Exito ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] RequestTallerDto request)
        {
            var response = await _service.Actualizar(id, request);
            
            return response.Exito ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = await _service.Eliminar(id);
            return response.Exito ? Ok(response) : BadRequest(response);
        }
    }
}
