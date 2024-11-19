using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet] // GET /api/users
    [ProducesResponseType(typeof(List<GetUserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAll()
    {
        var response = await _userService.GetAllAsync();
        return Ok(response);
    }

    [HttpPost] // POST /api/users
    [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Add(CreateUserDto userDto)
    {
        var response = await _userService.AddAsync(userDto);
        return Ok(response);
    }

    [HttpPost("login")] // POST /api/users/login
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Login(LoginUserDto loginUserDto)
    {
        var response = await _userService.LoginAsync(loginUserDto);
        return Ok(response);
    }
}
