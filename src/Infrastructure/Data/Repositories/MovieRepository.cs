using Application.Interfaces.Repositories;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(
        ApiMovieContext context,
        IReadRepository<Movie> readRepository,
        IWriteRepository<Movie> writeRepository
    )
        : base(context, readRepository, writeRepository) { }

    public async Task<IEnumerable<UsuarioWithCommentsDto>> GetAllCommentsByTitleAsync(
        string movieCode
    )
    {
        Movie movie = await DbContext.Movies.FirstOrDefaultAsync(m => m.MovieCode == movieCode);

        if (movie == null)
            return [];

        var comment = await DbContext.Comments.Where(c => c.MovieId == movie.Id).ToListAsync();
        var user = await DbContext.User.Where(u => u.Id == comment.First().UsuarioId).ToListAsync();

        var comments = comment.Select(c => new UsuarioWithCommentsDto
        {
            Comment = c.Text,
            UserName = user.First().Name,
            Id = c.Id,
            Date = c.Date,
        });

        return comments;
    }

    public async Task<Movie> GetByTitleAsync(string movieCode)
    {
        return await DbContext
            .Movies.AsNoTracking()
            .FirstOrDefaultAsync(m => m.MovieCode == movieCode);
    }

    public async Task<IEnumerable<Movie>> GetFilteredAsync(FilterMovie filter)
    {
        var sortOptions = new Dictionary<string, Func<Movie, object>>(
            StringComparer.OrdinalIgnoreCase
        )
        {
            { "id", movie => movie.Id },
            { "title", movie => movie.Title },
            { "year", movie => movie.Year },
            { "duration", movie => movie.Duration },
        };

        var movies = await DbContext.Movies.AsNoTracking().ToListAsync();

        if (sortOptions.TryGetValue(filter.Title, out var sortKeySelector))
        {
            bool isDescending = string.Equals(
                filter.OrderBy,
                "desc",
                StringComparison.OrdinalIgnoreCase
            );

            movies = isDescending
                ? movies.OrderByDescending(sortKeySelector).ToList()
                : movies.OrderBy(sortKeySelector).ToList();
        }

        return movies;
    }

    public Task<IEnumerable<Movie>> GetFilteredAsync(string filter)
    {
        throw new NotImplementedException();
    }
}
