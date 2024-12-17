using Application.DTOs.User;

namespace Application.Validation;

public class UserCreationValidator : AbstractValidator<UserCreationDto>
{
    public UserCreationValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Password_Hash).NotEmpty().WithMessage("Password is required");
    }
}
