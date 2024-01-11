using BookRental.Dev.Application.Contracts.Persistence.Book;
using FluentValidation;

namespace BookRental.Dev.Application.Features.Book.Command.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IBookReadRepository _repository;

    public CreateBookCommandValidator(IBookReadRepository repository)
    {
        _repository = repository;

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(b => b)
            .MustAsync(BookNameIsUnique)
            .WithMessage("An book with the same name already exists.");

    }

    private async Task<bool> BookNameIsUnique(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var res = await _repository.GetAsync(x => x.Name == command.Name);
        return res == null;
    }
}