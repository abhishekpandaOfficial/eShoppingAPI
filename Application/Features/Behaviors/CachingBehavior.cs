using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

    public CachingBehavior(IMemoryCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        // Generate a cache key based on the request
        var cacheKey = GetCacheKey(request);

        // Check if the response is already in the cache
        if (_cache.TryGetValue(cacheKey, out TResponse cachedResponse))
        {
            _logger.LogInformation($"Cache hit for {typeof(TRequest).Name}.");
            return cachedResponse;
        }

        // If not in cache, process the request
        _logger.LogInformation($"Cache miss for {typeof(TRequest).Name}. Processing request.");

        var response = await next();

        // Cache the response
        _cache.Set(cacheKey, response, TimeSpan.FromMinutes(5)); // Cache duration of 5 minutes
        _logger.LogInformation($"Response for {typeof(TRequest).Name} cached.");

        return response;
    }

    private string GetCacheKey(TRequest request)
    {
        // Generate a unique cache key for the request.
        // You can customize this as needed, such as by including properties of the request.
        return $"{typeof(TRequest).FullName}-{System.Text.Json.JsonSerializer.Serialize(request)}";
    }
}