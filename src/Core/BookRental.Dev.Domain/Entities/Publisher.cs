using BookRental.Dev.Domain.Common;
using System.Text.Json.Serialization;

namespace BookRental.Dev.Domain.Entities
{
    public sealed class Publisher : EntityBase
    {
        public Publisher()
        {
            
        }
        public Publisher(string name, string publisherSpecId, List<Book>? books)
        {
            Name = name;
            PublisherSpecId = publisherSpecId;
            Books = books ?? [];
        }

        public Publisher(string name, string publisherSpecId)
        {
            Name = name;
            PublisherSpecId = publisherSpecId;
        }

        public string Name { get; set; }
        public string PublisherSpecId { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
