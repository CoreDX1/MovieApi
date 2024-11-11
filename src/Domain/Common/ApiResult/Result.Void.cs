namespace Domain.Common.ApiResult;

public class Result : Result<Result>
{
    public Result()
        : base() { }

    protected internal Result(ResultStatus status)
        : base(status) { }

    /// <summary>
    /// Represents a successful operation without return type
    /// </summary>
    /// <returns>A Result</returns>
    public static Result Success() => new();

    /// <summary>
    /// Represents a successful operation without return type
    /// </summary>
    /// <param name="successMessage">Sets the SuccessMessage property</param>
    /// <returns>A Result</returns>
    public static Result SuccessWithMessage(string successMessage) =>
        new() { Message = successMessage };

    /// <summary>
    /// Represents a successful operation and accepts a values as the result of the operation
    /// </summary>
    /// <param name="value">Sets the Value property</param>
    /// <returns>A Result<typeparamref name="T"/></returns>
    public static Result<T> Success<T>(T value) => new(value);
}
