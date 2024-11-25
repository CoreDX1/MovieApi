using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Services;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateMovieDto> _movieValidator;

    public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateMovieDto> movieValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _movieValidator = movieValidator;
    }

    public async Task<Result<List<GetMovieListDto>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.Read.ListAsync();

        if (movies == null) return Result<List<GetMovieListDto>>.NotFound();

        var moviesDto = _mapper.Map<List<GetMovieListDto>>(movies);

        return Result<List<GetMovieListDto>>.Success(moviesDto);
    }

    public async Task<Result<GetMovieDto>> GetByIdAsync(int id)
    {
        if (id <= 0) return Result<GetMovieDto>.Error("Invalid movie id");

        var movie = await _unitOfWork.Movie.Read.FindAsync(id);

        if (movie == null) return Result<GetMovieDto>.NotFound();

        var movieDto = _mapper.Map<GetMovieDto>(movie);
        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<GetMovieDto>> AddAsync(CreateMovieDto movie)
    {
        var validationResult = await _movieValidator.ValidateAsync(movie);

        if (!validationResult.IsValid)
            return Result<GetMovieDto>.Invalid(validationResult.AsErrors());

        // FluentValidation
        var movieEntity = _mapper.Map<Movie>(movie);

        IResult movieExists = await GetByTitleAsync(movie.Title);

        if (movieExists.IsConflict())
            return Result<GetMovieDto>.Conflict();

        await _unitOfWork.Movie.Write.AddAsync(movieEntity);

        var movieDto = _mapper.Map<GetMovieDto>(movieEntity);

        return Result<GetMovieDto>.Created(movieDto);
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<GetMovieDto>> GetByTitleAsync(string movieCode)
    {
        var movie = await _unitOfWork.Movie.GetByTitleAsync(movieCode);

        if (movie == null)
            return Result<GetMovieDto>.NotFound();

        var movieDto = _mapper.Map<GetMovieDto>(movie);
        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<GetMovieDto>> DeleteAsync(int id)
    {
        var movie = await GetByIdAsync(id);

        if (movie.IsNotFound())
            return Result<GetMovieDto>.NotFound();

        var movieDetails = await _unitOfWork.Movie.Write.DeleteByIdAsync(id);

        GetMovieDto movieDto = _mapper.Map<GetMovieDto>(movieDetails);

        return Result<GetMovieDto>.Success(movieDto);
    }

    public async Task<Result<List<UsuarioWithCommentsDto>>> GetCommentByTitleAsync(string movieCode)
    {
        var comments = await _unitOfWork.Movie.GetAllCommentsByTitleAsync(movieCode);

        if (comments == null)
            return Result<List<UsuarioWithCommentsDto>>.NotFound();

        var commentsDto = _mapper.Map<List<UsuarioWithCommentsDto>>(comments);

        return Result<List<UsuarioWithCommentsDto>>.Success(commentsDto);
    }
}
