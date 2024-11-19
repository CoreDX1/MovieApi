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
    private readonly IValidator<CreateUserDto> _validator;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<GetUserDto>> AddAsync(CreateUserDto userCreate)
    {
        var validationResult = await _validator.ValidateAsync(userCreate);

        if (!validationResult.IsValid)
            return Result<GetUserDto>.Invalid(validationResult.AsErrors());

        User emailExist = await _unitOfWork.User.EmailExistAsync(userCreate.Email);

        if (emailExist != null)
            return Result<GetUserDto>.Conflict();

        var newUser = new User() { Name = userCreate.Name, Email = userCreate.Email };

        User userEntity = await _unitOfWork.User.Write.AddAsync(newUser);

        var credential = new UsuarioCredenciale()
        {
            UsuarioId = userEntity.Id,
            PasswordHash = GeneratePasswordHash(userCreate.Password_Hash),
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

    public async Task<Result<bool>> LoginAsync(LoginUserDto loginUser)
    {
        var existingUser = await _unitOfWork.User.EmailExistAsync(loginUser.Email);

        if (existingUser == null)
            return Result<bool>.NotFound("Email not found");

        var userCredentials = await _unitOfWork.Credential.Read.FindAsync(existingUser.Id);

        var isPasswordCorrect = ValidatePassword(loginUser.Password, userCredentials.PasswordHash);

        if (!isPasswordCorrect)
            return Result<bool>.NotFound("Invalid password");

        await _unitOfWork.Credential.UpdateLogin(existingUser.Id);
        return Result<bool>.Success(isPasswordCorrect);
    }

    public string GeneratePasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 7);
    }

    public bool ValidatePassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    // public async Task<Result<bool>> ChangePasswordAsync(ChangePasswordDto changePassword)
    // {
    //     var existingUser = await _unitOfWork.User.EmailExistAsync(changePassword.Email);

    //     if (existingUser == null)
    //         return Result<bool>.NotFound("Email not found");

    //     var userCredentials = await _unitOfWork.Credential.Read.FindAsync(existingUser.Id);

    //     var isPasswordCorrect = ValidatePassword(changePassword.OldPassword, userCredentials.PasswordHash);

    //     if (!isPasswordCorrect)
    //         return Result<bool>.NotFound("Invalid password");

    //     var newPasswordHash = GeneratePasswordHash(changePassword.NewPassword);

    //     userCredentials.PasswordHash = newPasswordHash;

    //     await _unitOfWork.Credential.Write.UpdateAsync(userCredentials);

    //     return Result<bool>.Success(true);
    // }
}
