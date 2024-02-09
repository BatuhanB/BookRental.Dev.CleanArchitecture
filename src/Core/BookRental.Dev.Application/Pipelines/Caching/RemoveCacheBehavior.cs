using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace BookRental.Dev.Application.Pipelines.Caching;
public class RemoveCacheBehavior<TRequest, TResponse>
    (IDistributedCache distributedCache) 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>, ICacheRemoverRequest
{
    private readonly IDistributedCache _distributedCache = distributedCache;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.BypassCache)
        {
            return await next();
        }

        TResponse response = await next();

        if (request.CacheGroupKey != null)
        {
            byte[]? cachedGroup = await _distributedCache.GetAsync(request.CacheGroupKey, cancellationToken);
            if (cachedGroup != null)
            {
                HashSet<string> keysInGroup = JsonSerializer.Deserialize<HashSet<string>>(Encoding.Default.GetString(cachedGroup))!;
                foreach (string key in keysInGroup)
                {
                    await _distributedCache.RemoveAsync(key, cancellationToken);
                }

                await _distributedCache.RemoveAsync(request.CacheGroupKey, cancellationToken);
                await _distributedCache.RemoveAsync(key: $"{request.CacheGroupKey}SlidingExpiration", cancellationToken);
            }
        }

        if (request.CacheKey != null)
        {
            await _distributedCache.RemoveAsync(request.CacheKey, cancellationToken);
        }
        return response;
    }
}