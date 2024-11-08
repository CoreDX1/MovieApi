using Application.Common.Interfaces;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Domain.Common.ApiResult;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class MoviesServices : IMoviesServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<MovieDtoRequest> _movieValidator;

    public MoviesServices(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<MovieDtoRequest> movieValidator
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _movieValidator = movieValidator;
    }

    public async Task<Result<IReadOnlyList<MovieDtoResponse>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();

        // Si no hay movies, retorna una respuesta 404
        if (movies == null)
            return Result<IReadOnlyList<MovieDtoResponse>>.NotFound();

        // Si hay movies, mapea los movies a MovieDtoResponse y retorna la respuesta
        var moviesDto = _mapper.Map<IReadOnlyList<MovieDtoResponse>>(movies);

        return Result<IReadOnlyList<MovieDtoResponse>>.Success(moviesDto);
    }

    public async Task<Result<MovieDtoResponse>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return Result<MovieDtoResponse>.Error("Invalid movie id");
        }

        var movie = await _unitOfWork.Movie.GetByIdAsync(id);

        if (movie == null)
            return Result<MovieDtoResponse>.NotFound();

        var movieDto = _mapper.Map<MovieDtoResponse>(movie);
        return Result<MovieDtoResponse>.Success(movieDto);
    }

    public async Task<Result<MovieDtoResponse>> AddAsync(MovieDtoRequest movie)
    {
        var validationResult = _movieValidator.Validate(movie);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result<MovieDtoResponse>.Error(errors);
        }

        // FluentValidation
        var movieEntity = _mapper.Map<Movie>(movie);
        var movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.Status == ResultStatus.Exists)
            return Result<MovieDtoResponse>.Exist();

        await _unitOfWork.Movie.AddAsync(movieEntity);
        return Result<MovieDtoResponse>.Created(_mapper.Map<MovieDtoResponse>(movieEntity));
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<MovieDtoResponse>> GetByTitleAsync(string title)
    {
        var movie = await _unitOfWork.Movie.GetByTitleAsync(title);

        if (movie == null)
        {
            return Result<MovieDtoResponse>.Success();
        }

        return Result<MovieDtoResponse>.Exist();
    }
}
