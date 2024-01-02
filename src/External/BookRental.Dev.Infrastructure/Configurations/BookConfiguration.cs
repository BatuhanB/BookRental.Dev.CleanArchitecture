using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRental.Dev.Infrastructure.Configurations;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(b => b.PublishDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.Publishers)
            .WithMany(b => b.Books);

        builder.HasOne(b => b.Author)
            .WithMany(b => b.Books);
    }
}