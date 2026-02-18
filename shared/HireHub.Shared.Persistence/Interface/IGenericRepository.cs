namespace HireHub.Shared.Persistence.Interface;

public interface IGenericRepository<T>
{
    Task<T?> GetByIdAsync(params object?[] id);
    Task<T?> GetByIdAsync(object?[] id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> ExistsAsync(params object?[] id);
    Task<bool> ExistsAsync(object?[] id, CancellationToken cancellationToken);
}
