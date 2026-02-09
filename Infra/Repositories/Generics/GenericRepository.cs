using Domain.Interfaces.Generics;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Generics;

public class GenericRepository<T> : IGeneric<T> where T : class
{
    private readonly ContextBase _context;

    public GenericRepository(ContextBase context)
    {
        _context = context;
    }

    public async Task Add(T Object)
    {
        await _context.Set<T>().AddAsync(Object);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T Object)
    {
        _context.Set<T>().Remove(Object);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetEntityById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> List()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task Update(T Object)
    {
        _context.Set<T>().Update(Object);
        await _context.SaveChangesAsync();
    }
}
