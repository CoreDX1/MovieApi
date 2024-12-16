using Application.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;

public class WriteRepostory<T> : IWriteRepository<T>
    where T : class
{
    private readonly ApiMovieContext DbContext;

    public WriteRepostory(ApiMovieContext dbContex)
    {
        DbContext = dbContex;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default
    )
    {
        await DbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<T>().Remove(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await DbContext.Set<T>().FindAsync(id);

        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<T>().RemoveRange(entities);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        DbContext.Set<T>().Update(entity);
        await SaveChangesAsync(cancellationToken);
    }
}
