using Microsoft.Extensions.Logging;

namespace MyApp.Persistence.Services
{
    public sealed class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<RedisCacheService> _logger;
        public RedisCacheService(IDistributedCache cache, ILogger<RedisCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan ttl, CancellationToken cancellationToken = default)
        {
            try
            {
                var s = await _cache.GetStringAsync(key, cancellationToken);
                if (!string.IsNullOrWhiteSpace(s))
                    try { return JsonSerializer.Deserialize<T>(s); }
                    catch { await _cache.RemoveAsync(key, cancellationToken); }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache GET failed {Key}", key);
            }
            

            var value = await factory();
            try
            {
                await _cache.SetStringAsync(key, JsonSerializer.Serialize(value),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = ttl }, cancellationToken);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, "Cache SET failed {Key}", key);
            }

            return value;
        }
        public Task RemoveAsync(string key, CancellationToken cancellationToken = default) => _cache.RemoveAsync(key, cancellationToken);
    }
}
