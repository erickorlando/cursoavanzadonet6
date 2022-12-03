using GalaxyApp.AccesoDatos;
using GalaxyApp.Entidades;

namespace GalaxyApp.Repositorios;

public class InstructorRepository : IInstructorRepository
{
    private readonly InstitutoDbContext _context;

    public InstructorRepository(InstitutoDbContext context)
    {
        _context = context;
    }

    public async Task<int> Crear(Instructor instructor)
    {
        await _context.Set<Instructor>().AddAsync(instructor);
        return instructor.Id;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}