using Application.Common.Interfaces;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using AutoMapper;
using Domain.Common;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Services;

public class MoviesServices : IMoviesServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MoviesServices(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<MovieDtoResponse>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();

        // Si no hay movies, retorna una respuesta 404
        if (movies == null)
            return Result<IReadOnlyList<MovieDtoResponse>>.Error("No movies found");

        // Si hay movies, mapea los movies a MovieDtoResponse y retorna la respuesta
        var moviesDto = _mapper.Map<IReadOnlyList<MovieDtoResponse>>(movies);

        return Result<IReadOnlyList<MovieDtoResponse>>.Success(moviesDto);
    }

    public async Task<Result<MovieDtoResponse>> GetByIdAsync(int id)
    {
        var movie = await _unitOfWork.Movie.GetByIdAsync(id);

        if (movie == null)
            return Result<MovieDtoResponse>.Error("Movie not found");

        var movieDto = _mapper.Map<MovieDtoResponse>(movie);
        return Result<MovieDtoResponse>.Success(movieDto);
    }

    public Task<bool> AddAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }
}
