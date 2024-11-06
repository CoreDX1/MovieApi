using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class MoviesServices : IMoviesServices
{
    private readonly IUnitOfWork _unitOfWork;

    public MoviesServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();
        return movies;
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
