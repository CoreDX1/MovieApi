using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMovieRepository : IRepository<Movie>
{
    public Task<Movie> GetByTitleAsync(string movieCode);

    public Task<IEnumerable<UsuarioWithCommentsDto>> GetAllCommentsByTitleAsync(string movieCode);
}
