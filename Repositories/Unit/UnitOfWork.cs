using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaDbContext _context;
    public IClienteRepository Clientes { get; }

    public UnitOfWork(TiendaDbContext context, IClienteRepository clientes)
    {
        _context = context;
        Clientes = clientes;

    }
    
    public int SaveChanges() => _context.SaveChanges();
    public void Dispose() => _context.Dispose();
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

}