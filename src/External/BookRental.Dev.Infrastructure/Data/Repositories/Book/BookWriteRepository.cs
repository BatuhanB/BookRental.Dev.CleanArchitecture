using BookRental.Dev.Application.Contracts.Persistence.Book;
using BookRental.Dev.Infrastructure.Data.DbContexts;

namespace BookRental.Dev.Infrastructure.Data.Repositories.Book;

public class BookWriteRepository : WriteRepository<Domain.Entities.Book,AppDbContext>,IBookWriteRepository
{
    public BookWriteRepository(AppDbContext context) : base(context)
    {
    }
}