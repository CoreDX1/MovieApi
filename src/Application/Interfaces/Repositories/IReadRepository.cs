namespace Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : class 
{

    public Task<TEntity> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<TEntity> FindByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<TEntity> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<List<TEntity>> ListAsync();

    public Task<int> CountAsync(CancellationToken cancellationToken = default);
    public Task<bool> AnyAsync(CancellationToken cancellationToken = default);

}
