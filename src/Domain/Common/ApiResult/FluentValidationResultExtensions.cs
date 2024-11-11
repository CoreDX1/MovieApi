using FluentValidation.Results;

namespace Domain.Common.ApiResult;

public static class FluentValidationResultExtensions
{
    public static IEnumerable<ValidationError> AsErrors(this ValidationResult validationResult)
    {
        var resultErrors = new List<ValidationError>();

        foreach (var valFailure in validationResult.Errors)
        {
            resultErrors.Add(
                new ValidationError()
                {
                    ErrorMessage = valFailure.ErrorMessage,
                    ErrorCode = valFailure.ErrorCode,
                    Identifier = valFailure.PropertyName,
                }
            );
        }

        return resultErrors;
    }
}
