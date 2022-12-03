using GalaxyApp.Entidades;

namespace GalaxyApp.Repositorios;

public interface IInstructorRepository
{
    Task<int> Crear(Instructor instructor);

    Task SaveChangesAsync();
}