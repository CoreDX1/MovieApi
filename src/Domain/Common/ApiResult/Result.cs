using System.Text.Json.Serialization;
using Domain.Common.Constants;

namespace Domain.Common.ApiResult;

public class Result<T> : IResult
{
    protected Result() { }

    public Result(T value) => Data = value;

    protected internal Result(string successMessage) => Message = successMessage;

    protected internal Result(T value, string successMessage)
        : this(value) => Message = successMessage;

    protected Result(ResultStatus status) => Status = status;

    public static implicit operator T(Result<T> result) => result.Data;

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(Result result) =>
        new(default(T))
        {
            Status = result.Status,
            Errors = result.Errors,
            Message = result.Message,
            ValidationErrors = result.ValidationErrors,
        };

    [JsonIgnore]
    public ResultStatus Status { get; protected set; } = ResultStatus.Ok;

    [JsonInclude]
    public string Message { get; protected set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string> Errors { get; protected set; } = [];

    [JsonInclude]
    public IEnumerable<ValidationError> ValidationErrors { get; protected set; } = [];

    [JsonInclude]
    public T Data { get; init; }

    [JsonIgnore]
    public Type ValueType => typeof(T);

    [JsonInclude]
    public string Location { get; protected set; } = string.Empty;

    public object GetValue() => Data;

    // public static Result<T> Success(T value) => new(value, ReplyMessage.Success.Query);

    // <summary>
    // Representa una operacion exitosa sin valor de retorno
    /// </summary>
    /// <returns>Result<T></returns>
    public static Result<T> Success() =>
        new(ResultStatus.Ok) { Message = ReplyMessage.Success.Query };

    // <summary>
    // Representa una operación exitosa con un valor de retorno
    /// </summary>
    /// <param name="value">Valor de retorno</param>
    /// <returns>Result<T></returns>
    public static Result<T> Success(T value) =>
        new(ResultStatus.Ok) { Data = value, Message = ReplyMessage.Success.Query };

    public static Result<T> Created(T value) =>
        new(ResultStatus.Created) { Data = value, Message = ReplyMessage.Success.Save };

    public static Result<T> Created(T value, string location) =>
        new(ResultStatus.Created) { Data = value, Location = location };

    // <summary>
    // Representa un error que ocurre durante la ejecución de una servicio
    /// </summary>
    /// <param name="errorMessage">Mensaje de error</param>
    /// <returns>Result<T></returns>
    public static Result<T> Error(string errorMessage) =>
        new(ResultStatus.Error) { Message = errorMessage };

    public static Result<T> Error(List<string> errors) =>
        new(ResultStatus.Error) { Errors = errors, Message = ReplyMessage.Validate.ValidateError };

    public static Result<T> Exist() =>
        new(ResultStatus.Exists) { Message = ReplyMessage.Error.Exists };

    public static Result<T> NotFound() =>
        new(ResultStatus.NotFound) { Message = ReplyMessage.Error.NotFound };

    public static Result<T> NotFound(params string[] errorMessages) =>
        new(ResultStatus.NotFound) { Errors = errorMessages };

    public static Result<T> Invalid(params ValidationError[] validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = new List<ValidationError>(validationErrors),
        };

    public static Result<T> Invalid(IEnumerable<ValidationError> validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = new List<ValidationError>(validationErrors),
            Message = ReplyMessage.Validate.ValidateError,
        };

    public static Result<T> Conflict() =>
        new(ResultStatus.Conflict) { Message = ReplyMessage.Error.Exists };
}
