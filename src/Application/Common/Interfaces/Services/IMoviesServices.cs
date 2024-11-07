using Application.Common.Models;
using Domain.Common;
using Domain.Entities;

namespace Application.Common.Interfaces.Services;

public interface IMoviesServices
{
    Task<ApiResult<IReadOnlyList<MovieDtoResponse>>> GetAllAsync();
    Task<ApiResult<MovieDtoResponse>> GetByIdAsync(int id);

    Task<bool> AddAsync(Movie movie);
    Task<bool> DeleteAsync(int id);

    Task<Movie> UpdateAsync(Movie movie);
}
