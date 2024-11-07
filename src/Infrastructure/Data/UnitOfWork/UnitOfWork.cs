using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Data.Migrations;

namespace Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IMovieRepositories Movie { get; }

    private readonly ApiMovieContext dbContext;

    public UnitOfWork(IMovieRepositories movie, ApiMovieContext context)
    {
        Movie = movie;
        dbContext = context;
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
