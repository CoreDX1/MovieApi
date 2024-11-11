using Application.Interfaces.Repositories;
using Infrastructure.Data.Migrations;

namespace  Infrastructure.Data.Repositories;

public class ReadRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class
{
    public ReadRepository(ApiMovieContext dbContext) : base(dbContext)
    {
    }
}
