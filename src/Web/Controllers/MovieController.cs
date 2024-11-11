using Application.DTOs;
using Application.Interfaces.Services;
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
    [ProducesResponseType(typeof(IReadOnlyList<GetMovieListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> GetAll()
    {
        var movies = await _moviesServices.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetMovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> GetById(int id)
    {
        var movie = await _moviesServices.GetByIdAsync(id);
        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetMovieListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> Add(CreateMovieDto movie)
    {
        var movieDto = await _moviesServices.AddAsync(movie);
        return Ok(movieDto);
    }
}
