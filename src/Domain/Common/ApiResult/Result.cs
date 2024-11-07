using System.Text.Json.Serialization;

namespace Domain.Common.ApiResult;

public class Result<T> : IResult
{
    protected Result() { }

    public Result(T value) => Value = value;

    protected internal Result(T value, string successMessage)
        : this(value) => SuccessMessage = successMessage;

    protected Result(ResultStatus status) => Status = status;

    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(Result result) =>
        new(default(T))
        {
            Status = result.Status,
            Errors = result.Errors,
            SuccessMessage = result.SuccessMessage,
            ValidationErrors = result.ValidationErrors,
        };

    [JsonIgnore]
    public ResultStatus Status { get; protected set; } = ResultStatus.Ok;

    [JsonInclude]
    public string SuccessMessage { get; protected set; } = string.Empty;

    [JsonIgnore]
    public IEnumerable<string> Errors { get; protected set; } = [];

    [JsonIgnore]
    public IEnumerable<ValidationError> ValidationErrors { get; protected set; } = [];

    public T Value { get; init; }

    [JsonIgnore]
    public Type ValueType => typeof(T);

    [JsonIgnore]
    public string Location { get; protected set; } = string.Empty;

    public object GetValue() => Value;

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Success(T value, string successMessage) => new(value, successMessage);

    public static Result<T> Created(T value) => new(ResultStatus.Created) { Value = value };

    public static Result<T> Created(T value, string location) =>
        new(ResultStatus.Created) { Value = value, Location = location };

    public static Result<T> Error(string errorMessage) =>
        new(ResultStatus.Error) { Errors = [errorMessage] };
}