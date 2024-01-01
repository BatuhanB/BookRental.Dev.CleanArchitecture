using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Domain.Entities;
public sealed class Book(string name, DateTime publishDate, int stock, double price, Author author) : EntityBase
{
    public Book(string name, DateTime publishDate,
        int stock, double price,
        Author author, List<Publisher> publishers) : this(name, publishDate, stock, price, author)
    {
        Publishers = publishers ?? [];
    }

    public string Name { get; set; } = name;
    public DateTime PublishDate { get; set; } = publishDate;
    public int Stock { get; set; } = stock;
    public double Price { get; set; } = price;
    public Author Author { get; set; } = author;
    public List<Publisher>? Publishers { get; set; }
}