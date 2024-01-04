using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Infrastructure.Data.Repositories.Interfaces
{
    public interface IWriteRepository<T> where T : EntityBase
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
