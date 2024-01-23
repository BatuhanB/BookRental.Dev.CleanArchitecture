using BookRental.Dev.Application.Contracts.Persistence.Paging;

namespace BookRental.Dev.Application.Features.Book.Queries.GetAll;

public sealed class GetAllBooksListVm
    : BasePageableModel
{
    public IList<GetBookVm>? Items { get; set; }
};
