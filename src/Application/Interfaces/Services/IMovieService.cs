
using Application.DTOs;
using Domain.Common.ApiResult;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IMovieService
{
    Task<Result<List<GetMovieListDto>>> GetAllAsync();
    Task<Result<GetMovieDto>> GetByTitleAsync(string movieCode);
    Task<Result<GetMovieDto>> GetByIdAsync(int id);

    Task<Result<List<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(string movieCode);

    Task<Result<GetMovieDto>> AddAsync(CreateMovieDto movie);
    Task<Result<GetMovieDto>> DeleteAsync(int id);

    Task<Movie> UpdateAsync(Movie movie);
}
