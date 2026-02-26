using Domain.Interfaces.Generics;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositories.Generics;

public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
{
    private readonly DbContextOptions<ContextBase> _OptionsBuilder;

    public GenericRepository()
    {
        _OptionsBuilder = new DbContextOptions<ContextBase>();
    }

    public async Task Add(T Object)
    {
        using (var data = new ContextBase(_OptionsBuilder))
        {
            await data.Set<T>().AddAsync(Object);
            await data.SaveChangesAsync();
        }
    }

    public async Task Delete(T Object)
    {
        using (var data = new ContextBase(_OptionsBuilder))
        {
            data.Set<T>().Remove(Object);
            await data.SaveChangesAsync();
        }
    }

    public async Task<T> GetEntityById(int id)
    {
        using (var data = new ContextBase(_OptionsBuilder))
        {
            return await data.Set<T>().FindAsync(id);
        }
    }

    public async Task<List<T>> List()
    {
        using (var data = new ContextBase(_OptionsBuilder))
        {
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }
    }

    public async Task Update(T Object)
    {
        using (var data = new ContextBase(_OptionsBuilder))
        {
            data.Set<T>().Update(Object);
            await data.SaveChangesAsync();
        }
    }

    #region Dispose
    bool disposed = false;
    SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            handle.Dispose();
        }
        disposed = true;
    }
    #endregion
}
