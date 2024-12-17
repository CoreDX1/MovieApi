using Application.DTOs;
using Application.DTOs.User;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Common.ApiResult;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UserCreationDto> _validator;

    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<UserCreationDto> validator
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<UserDto>> AddAsync(UserCreationDto userCreate)
    {
        var validationResult = await _validator.ValidateAsync(userCreate);

        if (!validationResult.IsValid)
            return Result<UserDto>.Invalid(validationResult.AsErrors());

        Usuario emailExist = await _unitOfWork.User.EmailExistAsync(userCreate.Email);

        if (emailExist != null)
            return Result<UserDto>.Conflict();

        var newUser = new Usuario() { Name = userCreate.Name, Email = userCreate.Email };

        Usuario userEntity = await _unitOfWork.User.Write.AddAsync(newUser);

        var credential = new UsuarioCredenciale()
        {
            UsuarioId = userEntity.Id,
            PasswordHash = GeneratePasswordHash(userCreate.Password_Hash),
        };

        await _unitOfWork.Credential.Write.AddAsync(credential);

        var userDto = _mapper.Map<UserDto>(userEntity);

        return Result<UserDto>.Created(userDto);
    }

    public async Task<Result<List<UserDto>>> GetAllAsync()
    {
        var users = await _unitOfWork.User.Read.ListAsync();

        if (users == null)
            return Result<List<UserDto>>.NotFound();

        var usersDto = _mapper.Map<List<UserDto>>(users);

        return Result<List<UserDto>>.Success(usersDto);
    }

    public Task<Usuario> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> LoginAsync(UserLoginDto loginUser)
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

    // TODO: Genera contraseña
    public string GeneratePasswordHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 7);
    }

    // TODO: Valida la contraseña
    public bool ValidatePassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    public async Task<Result<bool>> ChangePasswordAsync(UpdateCredentialDto changePassword)
    {
        var existingUser = await _unitOfWork.User.EmailExistAsync(changePassword.Email);

        if (existingUser is null)
            return Result<bool>.NotFound("Email not found");

        var userCredentials = await _unitOfWork.Credential.Read.FindAsync(existingUser.Id);

        var isPasswordCorrect = ValidatePassword(
            changePassword.OldPassword,
            userCredentials.PasswordHash
        );

        if (!isPasswordCorrect)
            return Result<bool>.NotFound("Invalid password");

        var newPasswordHash = GeneratePasswordHash(changePassword.NewPassword);

        bool changePasswordResult = await _unitOfWork.Credential.ChangePasswordAsync(
            newPasswordHash,
            existingUser.Id
        );

        return Result<bool>.Success(changePasswordResult);
    }
}
