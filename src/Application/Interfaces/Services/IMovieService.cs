using Application.DTOs;
using Domain.Common.ApiResult;
using Domain.DTOs;

namespace Application.Interfaces.Services;

public interface IMovieService
{
    Task<Result<IList<GetMovieListDto>>> GetAllAsync();
    Task<Result<GetMovieDto>> GetByTitleAsync(string movieCode);
    Task<Result<GetMovieDto>> GetByIdAsync(int id);
    Task<Result<IList<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(string movieCode);

    Task<Result<GetMovieDto>> AddAsync(CreateMovieDto movie);
    Task<Result<IEnumerable<GetMovieDto>>> AddRangeAsync(IEnumerable<CreateMovieDto> movies);

    Task<Result<GetMovieDto>> DeleteAsync(int id);

    Task<Result<IList<GetMovieListDto>>> GetFilteredAsync(FilterMovie filter);

    Task<Result<GetMovieDto>> UpdateAsync(EditMovieRequestDto movie);
}
