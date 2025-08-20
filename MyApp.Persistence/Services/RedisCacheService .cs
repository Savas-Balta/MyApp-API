namespace MyApp.Persistence.Services
{
    public sealed class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan ttl, CancellationToken cancellationToken = default)
        {
            var s = await _cache.GetStringAsync(key, cancellationToken);
            if (!string.IsNullOrWhiteSpace(s)) return JsonSerializer.Deserialize<T>(s);

            var value = await factory();
            await _cache.SetStringAsync(key,JsonSerializer.Serialize(value),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = ttl},cancellationToken);
            return value;
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default) => _cache.RemoveAsync(key, cancellationToken);
    }
}
