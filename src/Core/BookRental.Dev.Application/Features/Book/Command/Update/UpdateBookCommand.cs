using BookRental.Dev.Application.Pipelines.Caching;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Command.Update;
public sealed record UpdateBookCommand(Guid Id, string Name, DateTime PublishDate, int Stock, double Price) : IRequest<UpdateBookCommandResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBooks";
}
