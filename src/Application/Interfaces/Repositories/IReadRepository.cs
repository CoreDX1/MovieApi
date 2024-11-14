namespace Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class {

    public Task<T> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<T> FindByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<T> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<List<T>> ListAsync(CancellationToken cancellationToken = default);

    public Task<int> CountAsync(CancellationToken cancellationToken = default);
    public Task<bool> AnyAsync(CancellationToken cancellationToken = default);

}
