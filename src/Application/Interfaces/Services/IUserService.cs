using Application.DTOs;
using Application.DTOs.Credential;
using Application.DTOs.User;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task<Usuario> GetByNameAsync(string name);
    public Task<Result<List<UserDto>>> GetAllAsync();

    public Task<Result<UserDto>> AddAsync(UserCreationDto user);

    public Task<Result<bool>> LoginAsync(UserLoginDto loginUser);

    public Task<Result<bool>> ChangePasswordAsync(CredentialUpdateDto changePassword);
}
