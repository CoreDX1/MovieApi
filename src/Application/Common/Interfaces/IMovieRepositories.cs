using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IMovieRepositories
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie> GetByIdAsync(int id);
    Task<bool> AddAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(int id);
}
