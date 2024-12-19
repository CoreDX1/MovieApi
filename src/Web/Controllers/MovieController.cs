using Application.DTOs.Comment;
using Application.DTOs.Movie;
using Application.Interfaces.Services;
using Domain.DTOs;
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
    [ProducesResponseType(typeof(IReadOnlyList<MovieListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieListDto>> GetAll()
    {
        var response = await _moviesServices.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")] // GET /api/movies/1
    [ProducesResponseType(typeof(MovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieListDto>> GetById(int id)
    {
        var response = await _moviesServices.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost] // POST /api/movies
    [ProducesResponseType(typeof(MovieListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieListDto>> Add([FromBody] MovieCreationDto movieDto)
    {
        var response = await _moviesServices.AddAsync(movieDto);
        return Ok(response);
    }

    [HttpPost("range")] // POST /api/movies/range
    [ProducesResponseType(typeof(IEnumerable<MovieListDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<MovieListDto>>> AddRange(
        IEnumerable<MovieCreationDto> movie
    )
    {
        var response = await _moviesServices.AddRangeAsync(movie);
        return Ok(response);
    }

    [HttpDelete("{id}")] // DELETE /api/movies/1
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieListDto>> Delete(int id)
    {
        var response = await _moviesServices.DeleteAsync(id);
        return Ok(response);
    }

    [HttpGet("comment/{movieCode}")] // GET /api/movies/comment/1
    [ProducesResponseType(typeof(List<CommentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CommentListDto>>> GetCommentByTitle(
        [FromRoute] string movieCode
    )
    {
        var response = await _moviesServices.GetCommentByTitleAsync(movieCode);
        return Ok(response);
    }

    [HttpGet("title/{movieCode}")] // GET /api/movies/title/1
    [ProducesResponseType(typeof(MovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieListDto>> GetByTitle([FromRoute] string movieCode)
    {
        var response = await _moviesServices.GetByTitleAsync(movieCode);
        return Ok(response);
    }

    [HttpPost("filter")] // POST /api/movies/filter/
    [ProducesResponseType(typeof(IEnumerable<MovieListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MovieListDto>>> GetFiltered(
        [FromBody] FilterMovie filter
    )
    {
        var response = await _moviesServices.GetFilteredAsync(filter);
        return Ok(response);
    }

    [HttpPut("{id}")] // PUT /api/movies/1
    [ProducesResponseType(typeof(MovieListDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<MovieListDto>> Update(
        [FromRoute] int id,
        [FromBody] MovieUpdateDto movie
    )
    {
        var response = await _moviesServices.UpdateAsync(id, movie);
        return Ok(response);
    }
}
