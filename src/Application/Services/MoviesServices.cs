using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Services;

public class MoviesServices : IMoviesServices
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;
    private readonly IValidator<CreateMovieDto> _movieValidator;

    public MoviesServices(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateMovieDto> movieValidator
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _movieValidator = movieValidator;
    }

    public async Task<Result<List<GetMovieListDto>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.Read.ListAsync();

        if (movies is null)
            return Result<List<GetMovieListDto>>.NotFound();

        // Si hay movies, mapea los movies a GetMovieListDto y retorna la respuesta
        var moviesDto = _mapper.Map<List<GetMovieListDto>>(movies);

        return Result<List<GetMovieListDto>>.Success(moviesDto);
    }

    public async Task<Result<GetMovieListDto>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return Result<GetMovieListDto>.Error("Invalid movie id");
        }

        var movie = await _unitOfWork.Movie.Read.FindAsync(id);

        if (movie is null)
            return Result<GetMovieListDto>.NotFound();

        var movieDto = _mapper.Map<GetMovieListDto>(movie);
        return Result<GetMovieListDto>.Success(movieDto);
    }

    public async Task<Result<GetMovieListDto>> AddAsync(CreateMovieDto movie)
    {
        var validationResult = await _movieValidator.ValidateAsync(movie);

        if (!validationResult.IsValid)
        {
            return Result<GetMovieListDto>.Invalid(validationResult.AsErrors());
        }

        // FluentValidation
        var movieEntity = _mapper.Map<Movie>(movie);

        IResult movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.IsConflict())
            return Result<GetMovieListDto>.Conflict();

        await _unitOfWork.Movie.Write.AddAsync(movieEntity);
        return Result<GetMovieListDto>.Created(_mapper.Map<GetMovieListDto>(movieEntity));
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<GetMovieListDto>> GetByTitleAsync(string title)
    {
        var movie = await _unitOfWork.Movie.GetByTitleAsync(title);

        if (movie == null)
        {
            return Result<GetMovieListDto>.Success();
        }

        return Result<GetMovieListDto>.Conflict();
    }
}
