using BookRental.Dev.Domain.Common;

namespace BookRental.Dev.Application.Contracts
{
    public interface IWriteRepository<T> where T : EntityBase
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
