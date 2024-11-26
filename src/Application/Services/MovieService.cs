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

    public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateMovieDto> movieValidator)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        MovieValidator = movieValidator;
    }

    public async Task<Result<List<GetMovieListDto>>> GetAllAsync()
    {
        var movies = await UnitOfWork.Movie.Read.ListAsync();

        if (movies.Count == 0)
            return Result<List<GetMovieListDto>>.NotFound();

        var moviesDto = Mapper.Map<List<GetMovieListDto>>(movies);

        return Result<List<GetMovieListDto>>.Success(moviesDto);
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

        IResult movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.IsConflict())
            return Result<GetMovieDto>.Conflict();

        await UnitOfWork.Movie.Write.AddAsync(movieEntity);

        var movieDto = Mapper.Map<GetMovieDto>(movieEntity);

        return Result<GetMovieDto>.Created(movieDto);
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

        var movieDetails = await UnitOfWork.Movie.Write.DeleteByIdAsync(id);

        GetMovieDto movieDto = Mapper.Map<GetMovieDto>(movieDetails);

        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<List<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(string movieCode)
    {
        var comments = await UnitOfWork.Movie.GetAllCommentsByTitleAsync(movieCode);

        if (comments == null)
            return Result<List<UsuarioWithCommentsDto>>.NotFound();

        var commentsDto = Mapper.Map<List<UsuarioWithCommentsDto>>(comments);

        return Result<List<UsuarioWithCommentsDto>>.Success(commentsDto);
    }
}
