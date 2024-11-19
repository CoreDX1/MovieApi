using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApiMovieContext context, IReadRepository<User> readRepository, IWriteRepository<User> writeRepository)
        : base(context, readRepository, writeRepository) { }

    public async Task<bool> EmailExistAsync(string email)
    {
        return await DbContext.Set<User>().AsNoTracking().AnyAsync(u => u.Email == email);
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await DbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return false;
        }

        var passwordHash = await DbContext
            .UserCredential.AsNoTracking()
            .FirstOrDefaultAsync(uc => uc.UsuarioId == user.Id);

        if (user == null || passwordHash.PasswordHash == password)
        {
            return false;
        }

        return true;
    }
}
