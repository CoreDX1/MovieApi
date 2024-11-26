using Application.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : class
{

    private bool IsNull() => DbContex == null;

    private readonly ApiMovieContext DbContex;

    public ReadRepository(ApiMovieContext dbContex)
    {
        DbContex = dbContex;
    }

    public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await DbContex.Set<TEntity>().AsNoTracking().AnyAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContex.Set<TEntity>().CountAsync(cancellationToken);
    }

    public virtual async Task<TEntity> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default)
        where Tid : notnull
    {
        return await DbContex.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> FindByIdAsync<Tid>(
        Tid id,
        CancellationToken cancellationToken = default
    )
        where Tid : notnull
    {
        return await DbContex.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> FindOrDefaultAsync<Tid>(
        Tid id,
        CancellationToken cancellationToken = default
    )
        where Tid : notnull
    {
        return await DbContex.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> ListAsync()
    {
        return await DbContex.Set<TEntity>().ToListAsync();
    }
}
