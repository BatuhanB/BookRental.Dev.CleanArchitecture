using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRental.Dev.Infrastructure.SeedData
{
    public class AuthorSeedData : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author("Author1 FirstName", "Author1 LastName", 45),
                new Author("Author2 FirstName", "Author2 LastName", 65));
        }
    }
}
