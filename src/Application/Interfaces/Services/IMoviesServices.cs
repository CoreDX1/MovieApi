using Application.DTOs;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IMoviesServices
{
    Task<Result<List<GetMovieListDto>>> GetAllAsync();
    Task<Result<GetMovieListDto>> GetByTitleAsync(string title);
    Task<Result<GetMovieListDto>> GetByIdAsync(int id);

    Task<Result<GetMovieListDto>> AddAsync(CreateMovieDto movie);
    Task<bool> DeleteAsync(int id);

    Task<Movie> UpdateAsync(Movie movie);
}
