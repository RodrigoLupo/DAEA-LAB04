using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    private readonly TiendaDbContext _context;
    public ProductoRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}