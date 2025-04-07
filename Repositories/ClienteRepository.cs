using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    private readonly TiendaDbContext _context;
    public ClienteRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}