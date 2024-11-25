using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CredentialRepository : Repository<UsuarioCredenciale>, ICredentialRepository
{
    public CredentialRepository(
        ApiMovieContext context,
        IReadRepository<UsuarioCredenciale> readRepository,
        IWriteRepository<UsuarioCredenciale> writeRepository
    )
        : base(context, readRepository, writeRepository) { }

    public async Task UpdateLogin(int id)
    {
        var user = await DbContext
            .UserCredential.Where(x => x.UsuarioId == id)
            .FirstOrDefaultAsync();

        user.LastLogin = DateTime.Now;

        DbContext.UserCredential.Update(user);

        await DbContext.SaveChangesAsync();
    }


    public async Task<bool> ChangePasswordAsync(string changePassword, int id)
    {
        var UserCredential = await DbContext
            .UserCredential.Where(x => x.UsuarioId == id)
            .FirstOrDefaultAsync();

        if (UserCredential == null)
            return false;

        UserCredential.PasswordHash = changePassword;
        DbContext.UserCredential.Update(UserCredential);

        await DbContext.SaveChangesAsync();

        return true;
    }
}
