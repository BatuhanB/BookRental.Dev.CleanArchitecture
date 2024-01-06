using BookRental.Dev.Application.Contracts.Persistence.Book;
using BookRental.Dev.Infrastructure.Data.DbContexts;

namespace BookRental.Dev.Infrastructure.Data.Repositories.Book
{
    public class BookReadRepository(AppDbContext context) : ReadRepository<Domain.Entities.Book, AppDbContext>(context), IBookReadRepository
    {
    }
}
