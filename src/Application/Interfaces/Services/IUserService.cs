using Application.DTOs;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task<User> GetByNameAsync(string name);
    public Task<Result<List<GetUserListDto>>> GetAllAsync();
}
