using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(ApiMovieContext context, IReadRepository<Comment> readRepository, IWriteRepository<Comment> writeRepository) : base(context, readRepository, writeRepository)
    {
    }
}
