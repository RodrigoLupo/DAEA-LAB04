using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class DetallesOrdenRepository : GenericRepository<DetallesOrden>, IDetallesOrdenRepository
{
    private readonly TiendaDbContext _context;
    public DetallesOrdenRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}