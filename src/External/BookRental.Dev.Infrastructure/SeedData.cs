using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Dev.Infrastructure
{
    public class SeedData
    {
        public SeedData(ModelBuilder builder)
        {
            var author1 = new Author("Author1 FirstName", "Author1 LastName", 45);
            var author2 = new Author("Author2 FirstName", "Author2 LastName", 35);

            builder.Entity<Book>().HasData(
                new Book("Book 1", DateTime.Now, 200, 200, author1),
            new Book("Book 2", DateTime.Now, 100, 100, author2));

            builder.Entity<Author>().HasData(author1);
            builder.Entity<Author>().HasData(author2);

            builder.Entity<Publisher>().HasData(
                new Publisher("Publisher 1", "3aAs2gLfds14j"),
            new Publisher("Publisher 2", "L9sf5jJfba745"));

        }
    }
}
