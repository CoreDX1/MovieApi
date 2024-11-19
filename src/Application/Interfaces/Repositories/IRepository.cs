namespace Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public IReadRepository<T> Read { get; }
    public IWriteRepository<T> Write { get; }
}
