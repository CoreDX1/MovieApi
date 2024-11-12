namespace Domain.Common.ApiResult;

public enum ResultStatus
{
    Ok,
    Created,
    Error,
    Forbidden,
    Unauthorized,
    Invalid,
    NotFound,
    NoContent,
    Exists,
    Conflict,
    CriticalError,
    Unavailable,
}
