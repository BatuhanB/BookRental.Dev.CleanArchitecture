using BookRental.Dev.Application.Contracts.Persistence.Book;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Command.Create;

public class CreateBookCommandHandler(
    IBookWriteRepository writeRepository,
    IBookReadRepository readRepository)
    : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
{
    public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var createBookCommandResponse = new CreateBookCommandResponse();

        var validator = new CreateBookCommandValidator(readRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createBookCommandResponse.Success = false;
            createBookCommandResponse.Errors = new();
            foreach (var error in validationResult.Errors)
            {
                createBookCommandResponse.Errors.Add(error.ErrorMessage);
            }
        }

        if (createBookCommandResponse.Success)
        {
            var book = new Domain.Entities.Book()
            {
                Name = request.Name,
                Price = request.Price,
                PublishDate = DateTime.Now,
                Stock = request.Stock
            };
            book = await writeRepository.AddAsync(book);
            createBookCommandResponse.Data = book;
            createBookCommandResponse.Message = "Book has been created successfully.";
        }

        return createBookCommandResponse;
    }
}