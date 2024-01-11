using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Application.Features.Book.Command.Create;

public sealed class CreateBookCommandResponse : Result<Domain.Entities.Book>
{
};