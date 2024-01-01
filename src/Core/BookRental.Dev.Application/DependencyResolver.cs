using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Dev.Application;
public static class DependencyResolver
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
    {
        var assembly = typeof(DependencyResolver).Assembly;

        services.AddMediatR(conf =>
                conf.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}