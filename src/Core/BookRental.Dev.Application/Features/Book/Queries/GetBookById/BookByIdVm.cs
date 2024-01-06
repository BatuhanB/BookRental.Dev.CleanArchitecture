namespace BookRental.Dev.Application.Features.Book.Queries.GetBookById;
public sealed record class BookByIdVm(Guid Id, string Name, DateTime PublishDate, int Stock, double Price);
