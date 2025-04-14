using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories.Unit;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaDbContext _context;
    public IClienteRepository Clientes { get; }
    public IProductoRepository Productos { get; }
    public ICategoriaRepository Categorias { get; }
    public IDetallesOrdenRepository DetallesOrdenes { get; }
    public IPagoRepository Pagos { get; }
    public IOrdeneRepository Ordenes { get; }

    public UnitOfWork(TiendaDbContext context, IClienteRepository clientes, IProductoRepository productos, ICategoriaRepository categorias, IDetallesOrdenRepository detallesOrdenes, IPagoRepository pagos, IOrdeneRepository ordenes)
    {
        _context = context;
        Clientes = clientes;
        Productos = productos;
        Categorias = categorias;
        DetallesOrdenes = detallesOrdenes;
        Pagos = pagos;
        Ordenes = ordenes;

    }
    public IGenericRepository<T> Repository<T>() where T : class
    {
        return new GenericRepository<T>(_context);
    }
    public int SaveChanges() => _context.SaveChanges();
    public void Dispose() => _context.Dispose();
    public async Task <int> SaveChangesAsync() => await _context.SaveChangesAsync();

}