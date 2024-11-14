using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IMovieRepositories Movie { get; }
    public ICommentRepository Comment { get; }

    private readonly ApiMovieContext _context;

    public UnitOfWork(IMovieRepositories movie, ApiMovieContext context, ICommentRepository comment)
    {
        _context = context;
        Comment = comment;
        Movie = movie;
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
