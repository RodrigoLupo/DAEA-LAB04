namespace Laboratorio04_Lupo.Repositories;

public interface IUnitOfWork:IDisposable
{
    IClienteRepository Clientes { get; }
    IProductoRepository Productos { get; }
    
    
    int SaveChanges();
    Task<int> SaveChangesAsync();

}