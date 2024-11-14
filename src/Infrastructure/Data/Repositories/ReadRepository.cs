using Application.Interfaces.Repositories;

namespace  Infrastructure.Data.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly ApiMovieContext DbContex;

    public ReadRepository(ApiMovieContext dbContex)
    {
        DbContex = dbContex;
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return DbContex.Set<T>().AsNoTracking().AnyAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContex.Set<T>().CountAsync(cancellationToken);
    }

    public async Task<T> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
         return await DbContex.Set<T>().FindAsync(id);
    }

    public async Task<T> FindByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
         return await DbContex.Set<T>().FindAsync(id);
    }

    public async Task<T> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
         return await DbContex.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContex.Set<T>().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }
}
    
