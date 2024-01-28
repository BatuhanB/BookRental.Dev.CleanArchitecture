using BookRental.Dev.Domain.Entities;
using BookRental.Dev.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Dev.WebApi.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigration(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (!dbContext.Database.EnsureCreated())
        {
            dbContext.Database.Migrate();
        }
        SeedData(dbContext);
    }

    private static void SeedData(AppDbContext dbContext)
    {
        if (!dbContext.Authors.Any() && !dbContext.Publishers.Any())
        {
            Console.WriteLine("--> Seeding Data");
            dbContext.Authors.AddRange(
                 new Author("Author1 FirstName", "Author1 LastName", 45),
                new Author("Author2 FirstName", "Author2 LastName", 65)
            );

            dbContext.Publishers.AddRange(
                new Publisher("Publisher1", "1k8g6Hf0ad9Z4"),
                new Publisher("Publisher2", "L9jf71jfyh9F9")
                );
            dbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> Data has already persisted in database!");
        }
    }
}