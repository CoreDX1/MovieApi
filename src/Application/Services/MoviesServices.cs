using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;

namespace Application.Services;

public class MoviesServices : IMoviesServices
{
    private readonly IUnitOfWork _unitOfWork;

    public MoviesServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResult<IReadOnlyList<Movie>>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();

        if (!movies.Any())
            return ApiResult<IReadOnlyList<Movie>>.NotFound();

        return ApiResult<IReadOnlyList<Movie>>.Succes(movies);
    }

    public Task<bool> AddAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateAsync(Movie movie)
    {
        throw new NotImplementedException();
    }
}
