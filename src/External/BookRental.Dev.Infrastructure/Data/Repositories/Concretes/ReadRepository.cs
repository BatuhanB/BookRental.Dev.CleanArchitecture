using BookRental.Dev.Domain.Common;
using BookRental.Dev.Infrastructure.Data.Dynamic;
using BookRental.Dev.Infrastructure.Data.Interfaces;
using BookRental.Dev.Infrastructure.Data.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BookRental.Dev.Infrastructure.Data.Repositories.Concretes
{
    public class ReadRepository<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : EntityBase
        where TContext : DbContext
    {
        protected TContext Context { get; set; }

        public ReadRepository(TContext context)
        {
            Context = context;
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            TEntity? item = include == null
                          ? await Context.Set<TEntity>().FirstOrDefaultAsync(predicate)
                          : await include(Context.Set<TEntity>()).FirstOrDefaultAsync(predicate);

            return item;
        }
        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                               null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                               include = null,
                                                           int index = 0, int size = 10, bool enableTracking = true,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                    Func<IQueryable<TEntity>,
                                                                            IIncludableQueryable<TEntity, object>>?
                                                                        include = null,
                                                                    int index = 0, int size = 10,
                                                                    bool enableTracking = true,
                                                                    CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

    }
}
