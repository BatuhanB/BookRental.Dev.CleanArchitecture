using MediatR;

namespace BookRental.Dev.Application.Features.Book.Command.Create;

public sealed record CreateBookCommand(string Name,DateTime PublishDate,int Stock,double Price) : IRequest<CreateBookCommandResponse>;