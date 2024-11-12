using Application.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;


public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public IReadRepository<T> Read { get; set;} 
    public IWriteRepository<T> Write { get; set;}

    internal ApiMovieContext DbContext { get; set;}
    
    public RepositoryBase(ApiMovieContext context,IReadRepository<T> readRepository, IWriteRepository<T> writeRepository){
        Read = readRepository;
        Write = writeRepository;
        DbContext = context;
    }
}
