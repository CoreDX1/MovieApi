using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class MovieRepositories : RepositoryBase<Movie>, IMovieRepositories
{
    public MovieRepositories(
        ApiMovieContext context,
        IReadRepository<Movie> readRepository,
        IWriteRepository<Movie> writeRepository
    )
        : base(context, readRepository, writeRepository) { }

    public async Task<IEnumerable<Comment>> GetAllCommentsByTitleAsync(string movieCode)
    {
        var movie = await DbContext.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.MovieCode == movieCode);

        if (movie is null)
        {
            return [];
        }

        return await DbContext.Comments.Where(c => c.MovieId == movie.Id).ToListAsync();
    }

    public async Task<Movie> GetByTitleAsync(string movieCode)
    {
        return await DbContext.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.MovieCode == movieCode);
    }
}
