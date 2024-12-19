using Application.DTOs.Movie;
using Domain.Common.ApiResult;
using Domain.DTOs;

namespace Application.Interfaces.Services;

public interface IMovieService
{
    Task<Result<IList<MovieListDto>>> GetAllAsync();
    Task<Result<MovieDto>> GetByTitleAsync(string movieCode);
    Task<Result<MovieDto>> GetByIdAsync(int id);
    Task<Result<IList<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(string movieCode);

    Task<Result<MovieDto>> AddAsync(MovieCreationDto movie);
    Task<Result<IEnumerable<MovieDto>>> AddRangeAsync(IEnumerable<MovieCreationDto> movies);

    Task<Result<MovieDto>> DeleteAsync(int id);

    Task<Result<IList<MovieListDto>>> GetFilteredAsync(FilterMovie filter);

    Task<Result<MovieDto>> UpdateAsync(int id, MovieUpdateDto movie);
}
