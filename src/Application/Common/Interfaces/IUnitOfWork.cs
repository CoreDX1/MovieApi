namespace Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IMovieRepositories Movie { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
