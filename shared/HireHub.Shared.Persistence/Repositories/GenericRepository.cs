using HireHub.Shared.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace HireHub.Shared.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(params object?[] id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetByIdAsync(object?[] id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(params object?[] id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null;
    }

    public async Task<bool> ExistsAsync(object?[] id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync(id, cancellationToken);
        return entity != null;
    }
}

