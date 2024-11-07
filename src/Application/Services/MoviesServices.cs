using Application.Common.Interfaces;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using AutoMapper;
using Domain.Common;
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

    public async Task<ApiResult<IReadOnlyList<MovieDtoResponse>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();

        // Si no hay movies, retorna una respuesta 404
        if (movies == null)
            return ApiResult<IReadOnlyList<MovieDtoResponse>>.NotFound();

        // Si hay movies, mapea los movies a MovieDtoResponse y retorna la respuesta
        var moviesDto = _mapper.Map<IReadOnlyList<MovieDtoResponse>>(movies);

        return ApiResult<IReadOnlyList<MovieDtoResponse>>.Succes(moviesDto);
    }

    public async Task<ApiResult<MovieDtoResponse>> GetByIdAsync(int id)
    {
        var movie = await _unitOfWork.Movie.GetByIdAsync(id);

        if (movie == null)
            return ApiResult<MovieDtoResponse>.NotFound();

        var movieDto = _mapper.Map<MovieDtoResponse>(movie);
        return ApiResult<MovieDtoResponse>.Succes(movieDto);
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
