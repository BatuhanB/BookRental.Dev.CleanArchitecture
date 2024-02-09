using AutoMapper;
using BookRental.Dev.Application.Contracts.Persistence.Book;
using BookRental.Dev.Application.Pipelines.Caching;
using MediatR;
using Microsoft.Extensions.Options;

namespace BookRental.Dev.Application.Features.Book.Queries.GetAll;
public class BookGetAllQueryHandler(IBookReadRepository repository, IMapper mapper, IOptions<RedisSettings> redisSettingsOptions) : IRequestHandler<GetAllBookQuery, GetAllBooksListVm>
{
    private readonly IBookReadRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly RedisSettings _redisSettings = redisSettingsOptions.Value;

    public async Task<GetAllBooksListVm> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetListAsync(predicate: null,
                                                                orderBy: null,
                                                                null,
                                                                request.PageRequest.Page,
                                                                request.PageRequest.PageSize,
                                                                false,
                                                                cancellationToken: cancellationToken);
        var mappedBooks = _mapper.Map<GetAllBooksListVm>(books);
        return mappedBooks;
    }
}