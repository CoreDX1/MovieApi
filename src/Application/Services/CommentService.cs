using Application.DTOs;
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

    public async Task<Result<GetCommentDto>> AddAsync(CreateCommentDto comment)
    {
        var movie = await _unitOfWork.Comment.Read.FindAsync(comment.MovieId);

        if (movie is null)
            return Result<GetCommentDto>.NotFound();

        var movieDto = _mapper.Map<Comment>(comment);
        await _unitOfWork.Comment.Write.AddAsync(movieDto);

        var commentDto = _mapper.Map<GetCommentDto>(movieDto);

        return Result<GetCommentDto>.Created(commentDto);
    }

    public Task<Result<GetCommentDto>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<GetCommentListDto>>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comment.Read.ListAsync();
        if (comments is null)
            return Result<List<GetCommentListDto>>.NotFound();

        var commentsDto = _mapper.Map<List<GetCommentListDto>>(comments);

        return Result<List<GetCommentListDto>>.Success(commentsDto);
    }

    public Task<Result<GetCommentDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
