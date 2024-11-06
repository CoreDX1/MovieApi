using Application.Common.Interfaces;
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
    public async Task<IActionResult> GetAll()
    {
        var movies = await _moviesServices.GetAllAsync();
        return Ok(movies);
    }
}
