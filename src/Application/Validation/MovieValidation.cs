using Application.DTOs;

namespace Application.Validation;

public class MovieValidation : AbstractValidator<CreateMovieDto>
{
    public MovieValidation()
    {
        RuleFor(m => m.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .MinimumLength(3)
            .WithMessage("Title must be at least 3 characters")
            .MaximumLength(50)
            .WithMessage("Title must be at most 50 characters");
        RuleFor(m => m.Synopsis)
            .NotEmpty()
            .WithMessage("Description is required")
            .MinimumLength(3)
            .WithMessage("Description must be at least 3 characters")
            .MaximumLength(300)
            .WithMessage("Description must be at most 100 characters");
        ;
        RuleFor(m => m.Year).NotEmpty().WithMessage("Year is required");
        RuleFor(m => m.Duration).NotEmpty().WithMessage("Duration is required");
        RuleFor(m => m.Genre).NotEmpty().WithMessage("Genre is required");
    }
}
