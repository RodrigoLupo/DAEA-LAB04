using Laboratorio04_Lupo.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio04_Lupo.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{
    private readonly TiendaDbContext _context;

    public GenericRepository(TiendaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
    

    public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entityEntry = await _context.Set<T>().FindAsync(id);
        if (entityEntry != null)
        {
            _context.Set<T>().Remove(entityEntry);
            await _context.SaveChangesAsync();
        }
    }

}