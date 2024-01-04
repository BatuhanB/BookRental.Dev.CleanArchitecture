using BookRental.Dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRental.Dev.Infrastructure.Data.SeedData
{
    public class PublisherSeedData : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher("Publisher1", "1k8g6Hf0ad9Z4"),
                new Publisher("Publisher2", "L9jf71jfyh9F9"));
        }
    }
}
