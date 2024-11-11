namespace Application.Interfaces.Repositories;

public interface IReadRepository<T> : IRepositoryBase<T> where T : class {

    public Task<T> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    // public Task<T> FindByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<T> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    public Task<List<TResult>> ListAsync<TResult>(CancellationToken cancellationToken = default);
    
}
