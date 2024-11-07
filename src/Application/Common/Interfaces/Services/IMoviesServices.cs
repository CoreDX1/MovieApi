using Application.Common.Models;
using Domain.Common;
using Domain.Entities;

namespace Application.Common.Interfaces.Services;

public interface IMoviesServices
{
    Task<Result<IReadOnlyList<MovieDtoResponse>>> GetAllAsync();
    Task<Result<MovieDtoResponse>> GetByIdAsync(int id);

    Task<bool> AddAsync(Movie movie);
    Task<bool> DeleteAsync(int id);

    Task<Movie> UpdateAsync(Movie movie);
}
