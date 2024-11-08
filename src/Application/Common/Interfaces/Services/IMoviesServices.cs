using Application.Common.Models;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Common.Interfaces.Services;

public interface IMoviesServices
{
    Task<Result<IReadOnlyList<MovieDtoResponse>>> GetAllAsync();
    Task<Result<MovieDtoResponse>> GetByTitleAsync(string title);
    Task<Result<MovieDtoResponse>> GetByIdAsync(int id);

    Task<Result<MovieDtoResponse>> AddAsync(MovieDtoRequest movie);
    Task<bool> DeleteAsync(int id);

    Task<Movie> UpdateAsync(Movie movie);
}
