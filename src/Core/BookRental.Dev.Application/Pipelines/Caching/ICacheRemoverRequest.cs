﻿namespace BookRental.Dev.Application.Pipelines.Caching;
public interface ICacheRemoverRequest
{
    string? CacheKey { get; }
    bool BypassCache { get; }
    string? CacheGroupKey { get; }
}