using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Dev.Infrastructure;
public static class DependencyResolver
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
    {

        return services;
    }
}