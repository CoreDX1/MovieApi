namespace Domain.Common.Result;

public class Result<T> : IResult
{
    public ResultStatus Status => throw new NotImplementedException();

    public IEnumerable<string> Erorrs => throw new NotImplementedException();

    public IEnumerable<ValidationError> ValidationErrors => throw new NotImplementedException();

    public Type ValueType => throw new NotImplementedException();

    public string Location => throw new NotImplementedException();

    public object GetValue()
    {
        throw new NotImplementedException();
    }
}
