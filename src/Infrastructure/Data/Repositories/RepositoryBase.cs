using Application.Interfaces.Repositories;
using Infrastructure.Data.Migrations;

namespace Infrastructure.Data.Repositories;


public class RepositoryBase<T> : IReadRepository<T> where T : class
{
    private readonly ApiMovieContext DbContext;

    public RepositoryBase(ApiMovieContext dbContext)
    {
        DbContext = dbContext;
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        return await DbContext.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task<T> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        return await DbContext.Set<T>().FindAsync([id], cancellationToken);
    }

    public Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        throw new NotImplementedException();
    }


    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public Task<List<TResult>> ListAsync<TResult>(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
