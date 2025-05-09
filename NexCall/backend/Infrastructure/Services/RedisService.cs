using Core.Abstractions;
using StackExchange.Redis;

namespace Infrastructure.Services;

/// <summary>
/// Сервис работы с Redis
/// </summary>
public class RedisService : IRedisService
{
    private readonly IDatabase _db;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="redis">API для управления Redis сервером</param>
    public RedisService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    /// <inheritdoc />
    public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
    {
        await _db.StringSetAsync(key, value, expiry);
    }

    /// <inheritdoc />
    public async Task<string?> GetAsync(string key)
    {
        return await _db.StringGetAsync(key);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(string key)
    {
        return await _db.KeyDeleteAsync(key);
    }
}