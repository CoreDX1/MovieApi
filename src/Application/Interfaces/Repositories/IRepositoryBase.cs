namespace Application.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : class
{
    public IReadRepository<T> Read { get; }
    public IWriteRepository<T> Write { get; }
}
