using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IMoviesServices
{
    public Task<IEnumerable<Movie>> GetAllAsync();
    public Task<Movie> GetByIdAsync(int id);
    public Task<bool> AddAsync(Movie movie);
    public Task<bool> DeleteAsync(int id);
    public Task<Movie> UpdateAsync(Movie movie);
}
