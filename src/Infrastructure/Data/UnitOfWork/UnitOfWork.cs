using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Data.Migrations;

namespace Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IMovieRepositories Movie { get; }

    private readonly ApiMovieContext _context;

    public UnitOfWork(IMovieRepositories movie, ApiMovieContext context)
    {
        Movie = movie;
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
