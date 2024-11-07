using System.Reflection;
using Application.Common.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMoviesServices, MoviesServices>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
