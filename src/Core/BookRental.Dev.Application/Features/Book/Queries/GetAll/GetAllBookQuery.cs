using BookRental.Dev.Application.Contracts.Persistence.Request;
using BookRental.Dev.Application.Pipelines.Caching;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Queries.GetAll;

public sealed class GetAllBookQuery : IRequest<GetAllBooksListVm>,ICachableRequest
{
    public PageRequest? PageRequest { get; set; }

    public string CacheKey => $"GetAllBookQuery({PageRequest!.Page},{PageRequest!.PageSize})";

    public bool BypassCache { get; }

    public string? CacheGroupKey => $"GetBooks";

    public TimeSpan? SlidingExpiration { get; }
}
