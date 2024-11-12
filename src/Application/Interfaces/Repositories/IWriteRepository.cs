namespace  Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task<bool> DeleteAsync(T entity , CancellationToken cancellationToken = default);
}
