using System.ComponentModel;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMovieRepositories : IRepositoryBase<Movie>
{
    public Task<Movie> GetByTitleAsync(string title);
}
