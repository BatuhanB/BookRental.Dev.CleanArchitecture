using BookRental.Dev.Domain.Common;
using System.Text.Json.Serialization;

namespace BookRental.Dev.Domain.Entities;
public sealed class Author: EntityBase
{
    public Author()
    {
        
    }

    public Author(string firstName, string lastName, int age, List<Book>? books)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Books = books ?? [];
    }


    public Author(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public List<Book>? Books { get; set; }
}