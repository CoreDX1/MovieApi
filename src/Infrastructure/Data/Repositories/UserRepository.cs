using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(
        ApiMovieContext context,
        IReadRepository<User> readRepository,
        IWriteRepository<User> writeRepository
    )
        : base(context, readRepository, writeRepository) { }


    public async Task<User> EmailExistAsync(string email)
    {
         return await DbContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }
}
