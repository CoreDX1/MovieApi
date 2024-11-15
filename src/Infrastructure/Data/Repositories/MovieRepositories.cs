using Application.Interfaces.Repositories;
using Domain.DTOs;
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

    public async Task<IEnumerable<UsuarioWithCommentsDto>> GetAllCommentsByTitleAsync(
        string movieCode
    )
    {
        var movie = await DbContext
            .Movies.AsNoTracking()
            .FirstOrDefaultAsync(m => m.MovieCode == movieCode);

        if (movie is null)
        {
            return [];
        }

        var comments = await DbContext
            .Movies.Where(m => m.MovieCode == movieCode)
            .SelectMany(m =>
                m.Comments.Select(c => new UsuarioWithCommentsDto
                {
                    Id = c.Id,
                    UserName = c.Usuario.Name,
                    Date = c.Date,
                    Comment = c.Text,
                })
            )
            .ToListAsync();


        return comments;
    }

    public async Task<Movie> GetByTitleAsync(string movieCode)
    {
        return await DbContext
            .Movies.AsNoTracking()
            .FirstOrDefaultAsync(m => m.MovieCode == movieCode);
    }
}
