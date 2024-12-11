using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Services;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;
    private readonly IValidator<CreateMovieDto> MovieValidator;

    public MovieService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateMovieDto> movieValidator
    )
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        MovieValidator = movieValidator;
    }

    public async Task<Result<IList<GetMovieListDto>>> GetAllAsync()
    {
        var movies = await UnitOfWork.Movie.Read.ListAsync();

        if (movies.Count == 0)
            return Result<IList<GetMovieListDto>>.NotFound();

        var moviesDto = Mapper.Map<List<GetMovieListDto>>(movies);

        return Result<IList<GetMovieListDto>>.Success(moviesDto);
    }

    public async Task<Result<GetMovieDto>> GetByIdAsync(int id)
    {
        if (id <= 0)
            return Result<GetMovieDto>.Error("Invalid movie id");

        var movie = await UnitOfWork.Movie.Read.FindAsync(id);

        if (movie == null)
            return Result<GetMovieDto>.NotFound();

        var movieDto = Mapper.Map<GetMovieDto>(movie);
        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<GetMovieDto>> AddAsync(CreateMovieDto movie)
    {
        var validationResult = await MovieValidator.ValidateAsync(movie);

        if (!validationResult.IsValid)
            return Result<GetMovieDto>.Invalid(validationResult.AsErrors());

        // FluentValidation
        var movieEntity = Mapper.Map<Movie>(movie);

        var movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.IsConflict())
            return Result<GetMovieDto>.Conflict();

        await UnitOfWork.Movie.Write.AddAsync(movieEntity);

        var movieDto = Mapper.Map<GetMovieDto>(movieEntity);

        return Result<GetMovieDto>.Created(movieDto);
    }

    public async Task<Result<IEnumerable<GetMovieDto>>> AddRangeAsync(
        IEnumerable<CreateMovieDto> movies
    )
    {
        var movieEntity = Mapper.Map<List<Movie>>(movies);
        await UnitOfWork.Movie.Write.AddRangeAsync(movieEntity);

        var movieDto = Mapper.Map<List<GetMovieDto>>(movieEntity);
        return Result<IEnumerable<GetMovieDto>>.Created(movieDto);
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<GetMovieDto>> GetByTitleAsync(string movieCode)
    {
        var movie = await UnitOfWork.Movie.GetByTitleAsync(movieCode);

        if (movie == null)
            return Result<GetMovieDto>.NotFound();

        var movieDto = Mapper.Map<GetMovieDto>(movie);
        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<GetMovieDto>> DeleteAsync(int id)
    {
        var movie = await GetByIdAsync(id);

        if (movie.IsNotFound())
            return Result<GetMovieDto>.NotFound();

        await UnitOfWork.Movie.Write.DeleteByIdAsync(id);
        return Result<GetMovieDto>.Success();
    }

    public async Task<Result<IList<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(
        string movieCode
    )
    {
        var comments = await UnitOfWork.Movie.GetAllCommentsByTitleAsync(movieCode);

        if (comments == null)
            return Result<IList<UsuarioWithCommentsDto>>.NotFound();

        var commentsDto = Mapper.Map<List<UsuarioWithCommentsDto>>(comments);

        return Result<IList<UsuarioWithCommentsDto>>.Success(commentsDto);
    }
}
