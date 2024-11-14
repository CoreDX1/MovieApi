using System.Reflection;
using Application.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ICommentService, CommentService>();

        // Libreria de AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Libreria de FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
