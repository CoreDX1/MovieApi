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

        var comments = comment.Select(c => new UsuarioWithCommentsDto {
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
}
