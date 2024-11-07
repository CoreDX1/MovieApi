namespace Domain.Common.Result;

public class ValidationError
{
    public ValidationError(string errorMessage) => ErrorMessage = errorMessage;

    public ValidationError(string identifier, string errorMessage)
    {
        Identifier = identifier;
        ErrorMessage = errorMessage;
    }

    public ValidationError(string identifier, string errorMessage, string errorCode)
    {
        Identifier = identifier;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public string Identifier { get; set; }

    // TODO: Mark required and limit setting (see #179)
    public string ErrorMessage { get; set; }
    public string ErrorCode { get; set; }
}
