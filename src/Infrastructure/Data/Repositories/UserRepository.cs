using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class UserRepository : Repository<Usuario>, IUserRepository
{
    public UserRepository(
        ApiMovieContext context,
        IReadRepository<Usuario> readRepository,
        IWriteRepository<Usuario> writeRepository
    )
        : base(context, readRepository, writeRepository) { }


    public async Task<Usuario> EmailExistAsync(string email)
    {
         return await DbContext.Set<Usuario>().AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }
}
