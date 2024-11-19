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

    public async Task<Result<GetUserDto>> AddAsync(CreateUserDto userCreate)
    {
        var user = new User() { Name = userCreate.Name, Email = userCreate.Email };

        var emailExist = await _unitOfWork.User.EmailExistAsync(user.Email);

        if(emailExist){
            return Result<GetUserDto>.Conflict();
        }

        var userEntity = await _unitOfWork.User.Write.AddAsync(user);

        var credential = new UsuarioCredenciale()
        {
            UsuarioId = userEntity.Id,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userCreate.Password_Hash, 7),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            LastLogin = DateTime.Now,
        };

        await _unitOfWork.Credential.Write.AddAsync(credential);

        var userDto = _mapper.Map<GetUserDto>(userEntity);

        return Result<GetUserDto>.Created(userDto);
    }

    public async Task<Result<List<GetUserDto>>> GetAllAsync()
    {
        var users = await _unitOfWork.User.Read.ListAsync();

        if (users == null)
            return Result<List<GetUserDto>>.NotFound();

        var usersDto = _mapper.Map<List<GetUserDto>>(users);

        return Result<List<GetUserDto>>.Success(usersDto);
    }

    public Task<User> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    // public Task<bool> LoginAsync(LoginUserDto loginUser){
    // }

}


