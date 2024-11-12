using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data.Migrations;

namespace Infrastructure.Data.Repositories;

public class MovieRepositories : RepositoryBase<Movie>, IMovieRepositories
{
    public MovieRepositories(
        ApiMovieContext context,
        IReadRepository<Movie> readRepository,
        IWriteRepository<Movie> writeRepository
    )
        : base(context, readRepository, writeRepository) { }

    public Task<Movie> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }
}
