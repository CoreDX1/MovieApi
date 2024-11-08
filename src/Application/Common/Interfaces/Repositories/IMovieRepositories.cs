using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface IMovieRepositories
{
    Task<IReadOnlyList<Movie>> GetAllAsync();
    Task<Movie> GetByTitleAsync(string title);
    Task<Movie> GetByIdAsync(int id);
    Task<bool> AddAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(int id);
}
