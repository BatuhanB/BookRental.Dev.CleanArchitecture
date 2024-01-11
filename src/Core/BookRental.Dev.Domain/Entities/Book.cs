using BookRental.Dev.Domain.Common;
using System.Text.Json.Serialization;

namespace BookRental.Dev.Domain.Entities;
public sealed class Book : EntityBase
{
    public Book()
    {
        
    }

    public Book(string name, DateTime publishDate, int stock, double price, Author author, List<Publisher>? publishers)
    {
        Name = name;
        PublishDate = publishDate;
        Stock = stock;
        Price = price;
        Author = author;
        Publishers = publishers ?? [];
    }
    public Book(string name, DateTime publishDate, int stock, double price)
    {
        Name = name;
        PublishDate = publishDate;
        Stock = stock;
        Price = price;
    }

    public string Name { get; set; }
    public DateTime PublishDate { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    [JsonIgnore]
    public Author? Author { get; set; }
    [JsonIgnore]
    public List<Publisher>? Publishers { get; set; }
}