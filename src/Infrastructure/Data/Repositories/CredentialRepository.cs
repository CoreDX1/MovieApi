using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CredentialRepository : Repository<UsuarioCredenciale>, ICredentialRepository
{
    public CredentialRepository(ApiMovieContext context, IReadRepository<UsuarioCredenciale> readRepository, IWriteRepository<UsuarioCredenciale> writeRepository)
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
}
