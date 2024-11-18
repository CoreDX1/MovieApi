using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CredentialRepository : RepositoryBase<UsuarioCredenciale>, ICredentialRepository
{
    public CredentialRepository(ApiMovieContext context, IReadRepository<UsuarioCredenciale> readRepository, IWriteRepository<UsuarioCredenciale> writeRepository) : base(context, readRepository, writeRepository)
    {
    }
}