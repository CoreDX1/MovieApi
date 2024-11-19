using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User> EmailExistAsync(string email);
}
