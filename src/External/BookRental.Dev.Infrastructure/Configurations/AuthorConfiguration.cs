using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRental.Dev.Infrastructure.Configurations;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a => a.FirstName)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(a => a.FirstName)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(a => a.Age)
            .IsRequired();

        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.Books)
            .WithOne(a => a.Author);
    }
}