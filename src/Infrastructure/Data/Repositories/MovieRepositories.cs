using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class MovieRepositories : IMovieRepositories
{
    private readonly ApiMovieContext _context;

    public MovieRepositories(ApiMovieContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Movie>> GetAllAsync()
    {
        var movies = await _context.Movies.ToListAsync();
        return movies;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        return movie!;
    }

    public async Task<bool> AddAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie == null)
        {
            return false;
        }

        _context.Movies.Remove(movie);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
        return movie;
    }
}
