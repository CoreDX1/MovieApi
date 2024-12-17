using Application.DTOs;
using Application.DTOs.Comment;
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

    [HttpGet] // GET /api/comment
    [ProducesResponseType(typeof(IReadOnlyList<CommentListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CommentListDto>> GetAll()
    {
        var comments = await _commentService.GetAllAsync();
        return Ok(comments);
    }

    [HttpPost] // POST /api/comment
    [ProducesResponseType(typeof(CommentListDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CommentListDto>> Add(CommentCreationDto comment)
    {
        var commentDto = await _commentService.AddAsync(comment);
        return Ok(commentDto);
    }
}
