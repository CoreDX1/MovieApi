using Application.Interfaces.Repositories;
using Infrastructure.Data.Migrations;

namespace  Infrastructure.Data.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    private readonly ApiMovieContext DbContex;

    public ReadRepository(ApiMovieContext dbContex)
    {
        DbContex = dbContex;
    }

    public Task<T> FindAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        throw new NotImplementedException();
    }

    public Task<T> FindByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        throw new NotImplementedException();
    }

    public Task<T> FindOrDefaultAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContex.Set<T>().ToListAsync(cancellationToken: cancellationToken);
    }
}
    
