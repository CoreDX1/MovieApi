using Application.Interfaces.Repositories;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IMovieRepository Movie { get; }
    public ICommentRepository Comment { get; }
    public IUserRepository User { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
