using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Domain.Entities;
public sealed class Author(string firstName, string lastName, int age) : EntityBase
{
    public Author(string firstName, string lastName, 
        int age, List<Book> books) : this(firstName, lastName, age)
    {
        Books = books ?? [];
    }

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public int Age { get; set; } = age;
    public List<Book>? Books { get; set; }
}