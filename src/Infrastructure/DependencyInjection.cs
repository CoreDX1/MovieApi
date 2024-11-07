using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Data.Migrations;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<IMovieRepositories, MovieRepositories>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApiMovieContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}
