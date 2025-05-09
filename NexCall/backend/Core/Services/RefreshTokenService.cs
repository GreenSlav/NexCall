using Core.Abstractions;
using Core.Options;
using Microsoft.Extensions.Options;

namespace Core.Services;

/// <summary>
/// Сервис для работы с refresh-токенами
/// </summary>
public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRedisService _redisService;
    private readonly TimeSpan _tokenLifetime;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="redisService">Сервис для работы с Redis</param>
    /// <param name="options">Опции refresh-токена</param>
    public RefreshTokenService(IRedisService redisService, IOptions<RefreshTokenOptions> options)
    {
        _redisService = redisService;
        _tokenLifetime = TimeSpan.FromDays(options.Value.LifetimeDays);
    }

    /// <inheritdoc />
    public async Task<string> GenerateRefreshTokenAsync(long userId)
    {
        var token = Guid.NewGuid().ToString("N");
        var key = GetKey(token);

        await _redisService.SetAsync(key, userId.ToString(), _tokenLifetime);
        return token;
    }

    /// <inheritdoc />
    public async Task<long?> ValidateRefreshTokenAsync(string token)
    {
        var userIdString = await _redisService.GetAsync(GetKey(token));
        if (userIdString is null || !long.TryParse(userIdString, out var userId))
            return null;

        return userId;
    }

    /// <inheritdoc />
    public async Task InvalidateRefreshTokenAsync(string token)
    {
        await _redisService.DeleteAsync(GetKey(token));
    }
    
    private static string GetKey(string token) => $"refresh:{token}";
}