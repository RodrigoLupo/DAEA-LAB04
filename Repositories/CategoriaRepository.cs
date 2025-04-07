using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class CategoriaRepository: GenericRepository<Categoria>, ICategoriaRepository
{
    private readonly TiendaDbContext _context;
    public CategoriaRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}