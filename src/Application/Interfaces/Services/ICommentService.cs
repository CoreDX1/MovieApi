using Application.DTOs;
using Domain.Common.ApiResult;

namespace Application.Interfaces.Services;

public interface ICommentService
{
    Task<Result<List<GetCommentListDto>>> GetAllAsync();
    Task<Result<GetCommentDto>> GetByIdAsync(int id);

    Task<Result<GetCommentDto>> AddAsync(CreateCommentDto comment);
    Task<Result<GetCommentDto>> DeleteAsync(int id);
}
