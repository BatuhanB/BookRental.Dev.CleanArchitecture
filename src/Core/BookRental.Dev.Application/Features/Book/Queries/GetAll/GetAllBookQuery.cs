using BookRental.Dev.Application.Contracts.Persistence.Request;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Queries.GetAll;

public sealed class GetAllBookQuery : IRequest<GetAllBooksListVm>
{
    public PageRequest? PageRequest { get; set; } 
}
