using Application.DTOs.Credential;
using Application.DTOs.User;
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
    [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAll()
    {
        var response = await _userService.GetAllAsync();
        return Ok(response);
    }

    [HttpPost] // POST /api/users
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Add(UserCreationDto userDto)
    {
        var response = await _userService.AddAsync(userDto);
        return Ok(response);
    }

    [HttpPost("login")] // POST /api/users/login
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Login(UserLoginDto loginUserDto)
    {
        var response = await _userService.LoginAsync(loginUserDto);
        return Ok(response);
    }

    [HttpPut] // PUT /api/users
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> ChangePassword(CredentialUpdateDto updateCredentialDto)
    {
        var response = await _userService.ChangePasswordAsync(updateCredentialDto);
        return Ok(response);
    }
}
