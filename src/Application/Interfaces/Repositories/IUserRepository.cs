using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<Usuario>
{
    public Task<Usuario> EmailExistAsync(string email);
}
