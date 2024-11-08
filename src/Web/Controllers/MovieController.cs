using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMoviesServices _moviesServices;

    public MovieController(IMoviesServices moviesServices)
    {
        _moviesServices = moviesServices;
    }

    [HttpGet]
    public async Task<ActionResult<MovieDtoResponse>> GetAll()
    {
        var movies = await _moviesServices.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDtoResponse>> GetById(int id)
    {
        var movie = await _moviesServices.GetByIdAsync(id);
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDtoResponse>> Add(MovieDtoRequest movie)
    {
        var movieDto = await _moviesServices.AddAsync(movie);
        return Ok(movieDto);
    }
}
