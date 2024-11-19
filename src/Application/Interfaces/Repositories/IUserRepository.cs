using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>{

    public Task<bool> EmailExistAsync(string email);
}
