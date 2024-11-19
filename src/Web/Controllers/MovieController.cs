using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _moviesServices;

    public MovieController(IMovieService moviesServices)
    {
        _moviesServices = moviesServices;
    }

    [HttpGet] // GET /api/movies
    [ProducesResponseType(typeof(IReadOnlyList<GetMovieListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> GetAll()
    {
        var movies = await _moviesServices.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")] // GET /api/movies/1
    [ProducesResponseType(typeof(GetMovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> GetById(int id)
    {
        var movie = await _moviesServices.GetByIdAsync(id);
        return Ok(movie);
    }

    [HttpPost] // POST /api/movies
    [ProducesResponseType(typeof(GetMovieListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetMovieListDto>> Add(CreateMovieDto movieDto)
    {
        var movie = await _moviesServices.AddAsync(movieDto);
        return Ok(movie);
    }

    [HttpDelete("{id}")] // DELETE /api/movies/1
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetMovieListDto>> Delete(int id)
    {
        var movie = await _moviesServices.DeleteAsync(id);
        return Ok(movie);
    }


    [HttpGet("comment/{movieCode}")] // GET /api/movies/comment/1
    [ProducesResponseType(typeof(List<GetCommentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCommentListDto>>> GetCommentByTitle([FromRoute] string movieCode)
    {
        var comments = await _moviesServices.GetCommentByTitleAsync(movieCode);
        return Ok(comments);
    }

    [HttpGet("title/{movieCode}")] // GET /api/movies/title/1
    [ProducesResponseType(typeof(GetMovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetMovieListDto>> GetByTitle([FromRoute] string movieCode)
    {
        var movie = await _moviesServices.GetByTitleAsync(movieCode);
        return Ok(movie);
    }
}
