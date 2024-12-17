using Application.DTOs.Movie;
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
    private readonly IValidator<MovieCreationDto> MovieValidator;

    public MovieService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<MovieCreationDto> movieValidator
    )
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        MovieValidator = movieValidator;
    }

    public async Task<Result<IList<MovieListDto>>> GetAllAsync()
    {
        var movies = await UnitOfWork.Movie.Read.ListAsync();

        if (movies.Count == 0)
            return Result<IList<MovieListDto>>.NotFound();

        var moviesDto = Mapper.Map<List<MovieListDto>>(movies);

        return Result<IList<MovieListDto>>.Success(moviesDto);
    }

    public async Task<Result<MovieDto>> GetByIdAsync(int id)
    {
        if (id <= 0)
            return Result<MovieDto>.Error("Invalid movie id");

        var movie = await UnitOfWork.Movie.Read.FindAsync(id);

        if (movie == null)
            return Result<MovieDto>.NotFound();

        var movieDto = Mapper.Map<MovieDto>(movie);
        return Result<MovieDto>.Success(movieDto);
    }

    public async Task<Result<MovieDto>> GetByTitleAsync(string movieCode)
    {
        var movie = await UnitOfWork.Movie.GetByTitleAsync(movieCode);

        if (movie == null)
            return Result<MovieDto>.NotFound();

        var movieDto = Mapper.Map<MovieDto>(movie);
        return Result<MovieDto>.Success(movieDto);
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

    public async Task<Result<IList<MovieListDto>>> GetFilteredAsync(FilterMovie filter)
    {
        var movies = await UnitOfWork.Movie.GetFilteredAsync(filter);

        var moviesDto = Mapper.Map<List<MovieListDto>>(movies);

        return Result<IList<MovieListDto>>.Success(moviesDto);
    }

    public async Task<Result<MovieDto>> AddAsync(MovieCreationDto movie)
    {
        var validationResult = await MovieValidator.ValidateAsync(movie);

        if (!validationResult.IsValid)
            return Result<MovieDto>.Invalid(validationResult.AsErrors());

        // FluentValidation
        var movieEntity = Mapper.Map<Movie>(movie);

        var movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.IsConflict())
            return Result<MovieDto>.Conflict();

        await UnitOfWork.Movie.Write.AddAsync(movieEntity);

        var movieDto = Mapper.Map<MovieDto>(movieEntity);

        return Result<MovieDto>.Created(movieDto);
    }

    public async Task<Result<IEnumerable<MovieDto>>> AddRangeAsync(
        IEnumerable<MovieCreationDto> movies
    )
    {
        var movieEntity = Mapper.Map<List<Movie>>(movies);
        await UnitOfWork.Movie.Write.AddRangeAsync(movieEntity);

        var movieDto = Mapper.Map<List<MovieDto>>(movieEntity);
        return Result<IEnumerable<MovieDto>>.Created(movieDto);
    }

    public async Task<Result<MovieDto>> DeleteAsync(int id)
    {
        var movie = await GetByIdAsync(id);

        if (movie.IsNotFound())
            return Result<MovieDto>.NotFound();

        await UnitOfWork.Movie.Write.DeleteByIdAsync(id);
        return Result<MovieDto>.Success();
    }

    public async Task<Result<MovieDto>> UpdateAsync(MovieUpdateDto movie)
    {
        var movieEntity = Mapper.Map<Movie>(movie);
        var moviesId = await UnitOfWork.Movie.EditAsync(movieEntity);
        if (moviesId == null)
            return Result<MovieDto>.NotFound();

        var movieDto = Mapper.Map<MovieDto>(movieEntity);
        return Result<MovieDto>.Success(movieDto);
    }
}
