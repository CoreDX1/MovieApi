using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IMovieRepository Movie { get; }
    public ICommentRepository Comment { get; }
    public IUserRepository User { get; }
    public ICredentialRepository Credential { get; }

    private readonly ApiMovieContext _context;

    public UnitOfWork(
        IMovieRepository movie,
        ApiMovieContext context,
        ICommentRepository comment,
        IUserRepository user,
        ICredentialRepository credential
    )
    {
        _context = context;
        Comment = comment;
        Movie = movie;
        User = user;
        Credential = credential;
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
