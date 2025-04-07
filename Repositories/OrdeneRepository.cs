using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class OrdeneRepository : GenericRepository<Ordene>, IOrdeneRepository
{
    private readonly TiendaDbContext _context;
    public OrdeneRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}