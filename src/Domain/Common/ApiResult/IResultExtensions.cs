namespace Domain.Common.ApiResult;

public static class IResultExtensions
{
    /// <summary>
    /// Regresa verdadero si el resultado es Ok.
    /// </summary>
    public static bool IsOk(this IResult result) => result.Status == ResultStatus.Ok;

    /// <summary>
    /// Regresa verdadero si el resultado es Created.
    /// </summary>
    public static bool IsCreated(this IResult result) => result.Status == ResultStatus.Created;

    /// <summary>
    /// Regresa verdadero si el resultado es Error.
    /// </summary>
    public static bool IsError(this IResult result) => result.Status == ResultStatus.Error;

    /// <summary>
    /// Regresa verdadero si el resultado es Forbidden.
    /// </summary>
    public static bool IsForbidden(this IResult result) => result.Status == ResultStatus.Forbidden;

    /// <summary>
    /// Regresa verdadero si el resultado es Unauthorized.
    /// </summary>
    public static bool IsUnauthorized(this IResult result) => result.Status == ResultStatus.Unauthorized;

    /// <summary>
    /// Regresa verdadero si el resultado es invalido.
    /// </summary>
    public static bool IsInvalid(this IResult result) => result.Status == ResultStatus.Invalid;

    /// <summary>
    /// Returns true if the result is not found (status is NotFound).
    /// </summary>
    public static bool IsNotFound(this IResult result) => result.Status == ResultStatus.NotFound;

    /// <summary>
    /// Returns true if the result is no content (status is NoContent).
    /// </summary>
    public static bool IsNoContent(this IResult result) => result.Status == ResultStatus.NoContent;

    /// <summary>
    /// Returns true if the result is a conflict (status is Conflict).
    /// </summary>
    public static bool IsConflict(this IResult result) => result.Status == ResultStatus.Conflict;

    /// <summary>
    /// Returns true if the result is a critical error (status is CriticalError).
    /// </summary>
    public static bool IsCriticalError(this IResult result) => result.Status == ResultStatus.CriticalError;

    /// <summary>
    /// Returns true if the result is unavailable (status is Unavailable).
    /// </summary>
    public static bool IsUnavailable(this IResult result) => result.Status == ResultStatus.Unavailable;
}

