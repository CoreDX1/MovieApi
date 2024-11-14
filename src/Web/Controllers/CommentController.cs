using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<GetCommentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetCommentListDto>> GetAll()
    {
        var comments = await _commentService.GetAllAsync();
        return Ok(comments);
    }


    [HttpPost]
    [ProducesResponseType(typeof(GetCommentListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetCommentListDto>> Add(CreateCommentDto comment)
    {
        var commentDto = await _commentService.AddAsync(comment);
        return Ok(commentDto);
    }


}
