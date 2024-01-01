using BookRental.Dev.Infrastructure.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Dev.Infrastructure;
public static class DependencyResolver
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<AppDbContext>(
            configuration.GetConnectionString("DefaultConnection"));
        return services;
    }
}