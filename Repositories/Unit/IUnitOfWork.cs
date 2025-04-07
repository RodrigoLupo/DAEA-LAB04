namespace Laboratorio04_Lupo.Repositories;

public interface IUnitOfWork:IDisposable
{
    IClienteRepository Clientes { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync();

}