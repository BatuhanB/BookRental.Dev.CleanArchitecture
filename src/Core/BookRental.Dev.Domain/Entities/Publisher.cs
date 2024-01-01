using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Domain.Entities
{
    public sealed class Publisher(string name, string publisherSpecId) : EntityBase
    {
        public Publisher(string name, string publisherSpecId,
            List<Book>? books) : this(name, publisherSpecId)
        {
            Books = books ?? [];
        }

        public string Name { get; set; } = name;
        public string PublisherSpecId { get; set; } = publisherSpecId;
        public List<Book>? Books { get; set; }
    }
}
