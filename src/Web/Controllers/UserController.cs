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

    [HttpGet]
    [ProducesResponseType(typeof(List<GetUserListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetUserListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetUserListDto>> Add(CreateUserDto userDto)
    {
        var user = await _userService.AddAsync(userDto);
        return Ok(user);
    }
}
