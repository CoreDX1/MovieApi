using Application.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;


public class Repository<T> : IRepository<T> where T : class
{
    public IReadRepository<T> Read { get; set;}
    public IWriteRepository<T> Write { get; set;}

    internal ApiMovieContext DbContext { get;}

    public Repository(ApiMovieContext dbContext, IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
    {
        DbContext = dbContext;
         Read = readRepository;
         Write = writeRepository;
    }
}
