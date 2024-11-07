namespace Domain.Common.Result;

public interface IResult
{
    ResultStatus Status { get; }
    IEnumerable<string> Erorrs { get; }
    IEnumerable<ValidationError> ValidationErrors { get; }
    Type ValueType { get; }
    object GetValue();
    string Location { get; }
}
