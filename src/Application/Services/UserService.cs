using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetUserListDto>> AddAsync(CreateUserDto userCreate)
    {
        var user = new User() { Name = userCreate.Name, Email = userCreate.Email };

        var userEntity = await _unitOfWork.User.Write.AddAsync(user);

        var credential = new UsuarioCredenciale()
        {
            UsuarioId = userEntity.Id,
            PasswordHash = userCreate.Password_Hash,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            LastLogin = DateTime.Now,
        };

        await _unitOfWork.Credential.Write.AddAsync(credential);

        var userDto = _mapper.Map<GetUserListDto>(userEntity);

        return Result<GetUserListDto>.Success(userDto);
    }

    public async Task<Result<List<GetUserListDto>>> GetAllAsync()
    {
        var users = await _unitOfWork.User.Read.ListAsync();

        if (users == null)
            return Result<List<GetUserListDto>>.NotFound();

        var usersDto = _mapper.Map<List<GetUserListDto>>(users);

        return Result<List<GetUserListDto>>.Success(usersDto);
    }

    public Task<User> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}
