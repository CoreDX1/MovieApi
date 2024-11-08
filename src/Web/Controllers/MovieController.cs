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
    [ProducesResponseType(typeof(IReadOnlyList<MovieDtoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieDtoResponse>> GetAll()
    {
        var movies = await _moviesServices.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MovieDtoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieDtoResponse>> GetById(int id)
    {
        var movie = await _moviesServices.GetByIdAsync(id);
        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(typeof(MovieDtoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieDtoResponse>> Add(MovieDtoRequest movie)
    {
        var movieDto = await _moviesServices.AddAsync(movie);
        return Ok(movieDto);
    }
}
