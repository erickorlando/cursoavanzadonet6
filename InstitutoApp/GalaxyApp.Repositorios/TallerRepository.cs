using GalaxyApp.AccesoDatos;
using GalaxyApp.Entidades;
using GalaxyApp.Entidades.Infos;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.Repositorios
{
    public class TallerRepository : ITallerRepository
    {
        private readonly InstitutoDbContext _context;

        public TallerRepository(InstitutoDbContext context)
        {
            _context = context;
        }

        public async Task<(ICollection<TallerInfo> Lista, int Total)> Listar(string? filtro,
            int? categoriaId, int? situacion, int pagina, int filas)
        {
            var query = _context.Set<Taller>()
                .Where(p => p.Estado
                            && p.Nombre.Contains(filtro ?? string.Empty))
                .AsQueryable();

            if (categoriaId.HasValue)
            {
                query = query.Where(p => p.CategoriaId == categoriaId.Value);
            }

            if (situacion.HasValue)
            {
                query = query.Where(p => p.Situacion == (SituacionEnum)situacion.Value);
            }

            var coleccion = query
                .Select(p => new TallerInfo
                {
                    IdTaller = p.Id,
                    Nombre = p.Nombre,
                    Categoria = p.Categoria.Nombre,
                    FechaInicio = p.FechaInicio.ToString("dd/MM/yyyy"),
                    Situacion = p.Situacion.ToString(),
                    Instructor = $"{p.Instructor.Nombres} {p.Instructor.Apellidos}",
                    PortadaUrl = p.PortadaUrl
                });

            var collection = coleccion
                .OrderBy(p => p.Nombre)
                .Skip((pagina - 1) * filas)
                .Take(filas);


            var total = await query.CountAsync();

            return (await collection.ToListAsync(), total);
        }


        public async Task<Taller?> Obtener(int id)
        {
            return await _context.Set<Taller>()
                .FindAsync(id);
        }

        public async Task<int> Crear(Taller taller)
        {
            await _context.Set<Taller>().AddAsync(taller);
            return taller.Id;
        }

        public async Task Actualizar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task Eliminar(int id)
        {
            var taller = await Obtener(id);

            if (taller != null)
            {
                taller.Estado = false;
                await Actualizar();
            }
        }
    }
}