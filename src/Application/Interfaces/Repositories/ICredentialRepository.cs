using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICredentialRepository : IRepository<UsuarioCredenciale>
{
    public Task UpdateLogin(int id);
    public Task<bool> ChangePasswordAsync(string changePassword, int id);
}
