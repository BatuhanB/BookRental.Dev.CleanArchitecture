using AutoMapper;
using BookRental.Dev.Application.Contracts.Persistence.Book;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Queries.GetBookById
{
    public class GetBookByIdQueryHandler(IBookReadRepository repository, IMapper mapper) : IRequestHandler<GetBookByIdQuery, BookByIdVm>
    {
        private readonly IBookReadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BookByIdVm> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book =  await _repository.GetAsync(x => x.Id == request.Id);
            var mappedBook = _mapper.Map<BookByIdVm>(book) ?? throw new ArgumentNullException(Constants.Messages.BookNullExceptionMessage());
            return mappedBook;
        }
    }
}
