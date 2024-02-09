using BookRental.Dev.Application.Pipelines.Caching;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookRental.Dev.Application;
public static class DependencyResolver
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services,IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = configuration.GetConnectionString("RedisConnection");
        });

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            configuration.AddOpenBehavior(typeof(AddCacheBehavior<,>));
            configuration.AddOpenBehavior(typeof(RemoveCacheBehavior<,>));
        });
        services.AddValidatorsFromAssembly(assembly);        
        services.AddAutoMapper(assembly);

        return services;
    }
}