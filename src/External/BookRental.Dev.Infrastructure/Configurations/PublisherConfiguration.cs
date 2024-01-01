using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRental.Dev.Infrastructure.Configurations;
public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.Property(b => b.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(b => b.PublisherSpecId)
            .HasMaxLength(13)
            .IsRequired();

        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.Books)
            .WithMany(b => b.Publishers);
    }
}