using MediatR;

namespace BookRental.Dev.Application.Features.Book.Queries.GetBookById;
public class GetBookByIdQuery : IRequest<BookByIdVm>
{
    public Guid Id{ get; set; }
}
