using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMovieRepositories
{
    Task<List<Movie>> GetAllAsync();
    Task<Movie> GetByTitleAsync(string title);
    Task<Movie> GetByIdAsync(int id);
    Task<bool> AddAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(int id);
}
