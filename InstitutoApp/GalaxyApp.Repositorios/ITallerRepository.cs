using GalaxyApp.Entidades;
using GalaxyApp.Entidades.Infos;

namespace GalaxyApp.Repositorios;

public interface ITallerRepository
{
    Task<(ICollection<TallerInfo> Lista, int Total)> Listar(string? filtro,
        int? categoriaId, int? situacion, int pagina, int filas);

    Task<Taller?> Obtener(int id);
    Task<int> Crear(Taller taller);
    Task Actualizar();
    Task Eliminar(int id);
    Task CommitAsync();
    Task RollBackAsync();
    Task BeginTransactionAsync();
}