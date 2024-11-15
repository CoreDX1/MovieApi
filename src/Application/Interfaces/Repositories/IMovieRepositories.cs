using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMovieRepositories : IRepositoryBase<Movie>
{
    public Task<Movie> GetByTitleAsync(string movieCode);

    public Task<IEnumerable<UsuarioWithCommentsDto>> GetAllCommentsByTitleAsync(string movieCode);
}
