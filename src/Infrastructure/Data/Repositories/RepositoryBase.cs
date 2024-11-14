using Application.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;


public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public IReadRepository<T> Read { get; internal set;}
    public IWriteRepository<T> Write { get; internal set;}

    internal ApiMovieContext DbContext { get;}
    
    public RepositoryBase(ApiMovieContext context,IReadRepository<T> readRepository, IWriteRepository<T> writeRepository){
        Read = readRepository;
        Write = writeRepository;
        DbContext = context;
    }
}
