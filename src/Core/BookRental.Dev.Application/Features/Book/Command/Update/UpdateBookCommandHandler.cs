using BookRental.Dev.Application.Contracts.Persistence.Book;
using MediatR;

namespace BookRental.Dev.Application.Features.Book.Command.Update;
public class UpdateBookCommandHandler
    (IBookReadRepository readRepository,
    IBookWriteRepository writeRepository)
    : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
{
    public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateBookCommandResponse();

        var validator = new UpdateBookCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.Errors = [];
            foreach (var error in validationResult.Errors)
            {
                response.Errors.Add(error.ErrorMessage);
            }
        }

        if (response.Success)
        {
            var book = await readRepository.GetAsync(x => x.Id == request.Id);

            if (book == null)
            {
                response.Success = false;
                response.Errors.Add("Book not found!");
            }

            book.Name = request.Name;
            book.UpdateDate = DateTime.Now;
            book.Price = request.Price;
            book.Stock = request.Stock;
            book.PublishDate = request.PublishDate;

            book = await writeRepository.UpdateAsync(book);

            response.Data = book;
            response.Message = "Book has been updated successfully.";
        }
        return response;
    }
}