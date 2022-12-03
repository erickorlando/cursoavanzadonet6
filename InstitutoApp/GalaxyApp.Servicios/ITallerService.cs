using GalaxyApp.Dto.Request;
using GalaxyApp.Dto.Response;
using GalaxyApp.Entidades;
using GalaxyApp.Entidades.Infos;

namespace GalaxyApp.Servicios;

public interface ITallerService
{
    Task<BaseResponseList<TallerInfo>> Listar(RequestTallerBusqueda request);
    Task<BaseResponseGeneric<Taller>> Obtener(int id);
    Task<BaseResponse> Crear(RequestTallerDto request);
    Task<BaseResponse> Actualizar(int id, RequestTallerDto request);
    Task<BaseResponse> Eliminar(int id);
}