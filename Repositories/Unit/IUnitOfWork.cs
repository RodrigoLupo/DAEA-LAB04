namespace Laboratorio04_Lupo.Repositories.Unit;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<T> Repository<T>()where T : class;
    IClienteRepository Clientes { get; }
    IProductoRepository Productos { get; }
    ICategoriaRepository Categorias { get; }
    IDetallesOrdenRepository DetallesOrdenes { get; }
    IPagoRepository Pagos { get; }
    IOrdeneRepository Ordenes { get; }
    
    int SaveChanges();
    Task <int> SaveChangesAsync();

}