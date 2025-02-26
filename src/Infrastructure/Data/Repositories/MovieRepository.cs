using System.Linq.Expressions;
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

    public async Task<PaginatedList<Movie>> GetFilteredAsync(MovieFilterDto filter)
    {
        // Inicia la consulta como IQueryable
        IQueryable<Movie> query = DbContext.Movies;

        // Diccionario de opciones de ordenación
        var sortOptions = new Dictionary<string, Expression<Func<Movie, object>>>
        {
            ["id"] = movie => movie.Id,
            ["title"] = movie => movie.Title,
            ["year"] = movie => movie.Year,
            ["duration"] = movie => movie.Duration,
        };

        // Aplica la ordenación si el filtro es válido
        if (sortOptions.TryGetValue(filter.Name, out var sortKeySelector))
        {
            bool isDescending = string.Equals(
                filter.OrderBy,
                "desc",
                StringComparison.OrdinalIgnoreCase
            );

            query = isDescending
                ? query.OrderByDescending(sortKeySelector)
                : query.OrderBy(sortKeySelector);
        }

        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / filter.PageSize);
        query = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

        // Ejecuta la consulta y obtiene la lista de películas

        var result = new PaginatedList<Movie>
        {
            Item = await query.ToListAsync(),
            Page = filter.Page,
            PageSize = filter.PageSize,
            TotalPages = totalPages,
        };

        return result;
    }

    public async Task<Movie> EditAsync(int id, Movie movie)
    {
        // Obtiene el objeto Movie de la base de datos
        var movieEntity = await DbContext.Movies.FindAsync(id);

        if (movieEntity == null)
        {
            return null;
        }

        movieEntity.Title = movie.Title;
        movieEntity.Year = movie.Year;
        movieEntity.Duration = movie.Duration;
        movieEntity.Synopsis = movie.Synopsis;

        await DbContext.SaveChangesAsync();
        return movieEntity;
    }
}
