using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICredentialRepository : IRepository<UsuarioCredenciale>{
    public Task UpdateLogin(int id);
}
