namespace Domain.Common.ApiResult;

public interface IResult<T>
{
    ResultStatus Status { get; }
    IEnumerable<string> Errors { get; }
    IEnumerable<ValidationError> ValidationErrors { get; }
    Type ValueType { get; }
    object GetValue();
    string Location { get; }

    
}
