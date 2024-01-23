namespace BookRental.Dev.Application.Features.Book.Queries.GetAll;

public sealed record GetBookVm(Guid Id, string Name, DateTime PublishDate, int Stock, double Price);