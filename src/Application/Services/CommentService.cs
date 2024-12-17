using Application.DTOs;
using Application.DTOs.Comment;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CommentDto>> AddAsync(CommentCreationDto comment)
    {
        var movie = await _unitOfWork.Comment.Read.FindAsync(comment.MovieId);

        if (movie is null)
            return Result<CommentDto>.NotFound();

        var movieDto = _mapper.Map<Comment>(comment);
        await _unitOfWork.Comment.Write.AddAsync(movieDto);

        var commentDto = _mapper.Map<CommentDto>(movieDto);

        return Result<CommentDto>.Created(commentDto);
    }

    public Task<Result<CommentDto>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<CommentListDto>>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comment.Read.ListAsync();
        if (comments is null)
            return Result<List<CommentListDto>>.NotFound();

        var commentsDto = _mapper.Map<List<CommentListDto>>(comments);

        return Result<List<CommentListDto>>.Success(commentsDto);
    }

    public Task<Result<CommentDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
