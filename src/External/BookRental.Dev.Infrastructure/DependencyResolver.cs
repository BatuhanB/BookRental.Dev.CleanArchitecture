using BookRental.Dev.Application.Contracts;
using BookRental.Dev.Application.Contracts.Persistence.Book;
using BookRental.Dev.Domain.Entities;
using BookRental.Dev.Infrastructure.Data.DbContexts;
using BookRental.Dev.Infrastructure.Data.Repositories;
using BookRental.Dev.Infrastructure.Data.Repositories.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Dev.Infrastructure;
public static class DependencyResolver
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IReadRepository<Book>, ReadRepository<Book, AppDbContext>>();
        services.AddScoped<IWriteRepository<Book>, WriteRepository<Book, AppDbContext>>();
        services.AddScoped<IBookReadRepository, BookReadRepository>();
        return services;
    }
}