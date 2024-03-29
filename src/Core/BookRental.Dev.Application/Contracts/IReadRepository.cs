﻿using System.Linq.Expressions;
using BookRental.Dev.Application.Contracts.Persistence.Paging;
using BookRental.Dev.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace BookRental.Dev.Application.Contracts
{
    public interface IReadRepository<T> where T : EntityBase
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        Task<IPaginate<T>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 int index = 0, int size = 10, bool enableTracking = true,
                                                 CancellationToken cancellationToken = default);
        IQueryable<T> Query();
    }
}
