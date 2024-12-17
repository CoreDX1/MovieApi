using Application.DTOs.Comment;
using Domain.Common.ApiResult;

namespace Application.Interfaces.Services;

public interface ICommentService
{
    Task<Result<List<CommentListDto>>> GetAllAsync();
    Task<Result<CommentDto>> GetByIdAsync(int id);

    Task<Result<CommentDto>> AddAsync(CommentCreationDto comment);
    Task<Result<CommentDto>> DeleteAsync(int id);
}
