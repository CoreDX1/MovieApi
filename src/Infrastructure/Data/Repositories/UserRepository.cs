using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(
        ApiMovieContext context,
        IReadRepository<User> readRepository,
        IWriteRepository<User> writeRepository
    )
        : base(context, readRepository, writeRepository) { }
}
