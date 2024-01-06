using BookRental.Dev.Domain.Common;
using BookRental.Dev.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Dev.Infrastructure.Data.Repositories.Concretes
{
    public class WriteRepository<TEntity,TContext>:IWriteRepository<TEntity>
        where TEntity : EntityBase
        where TContext : DbContext
    {
        protected TContext Context { get; set; }
        public WriteRepository(TContext context)
        {

            Context = context;

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

    }
}
