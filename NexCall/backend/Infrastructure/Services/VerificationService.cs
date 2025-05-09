using System.Text.Json;
using Core.Abstractions;
using Core.Models;

namespace Infrastructure.Services;

/// <summary>
/// Сервис верификации
/// </summary>
public class VerificationService : IVerificationService
{
    private readonly IRedisService _redis;
    private const string Prefix = "register:";

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="redis">Redis</param>
    public VerificationService(IRedisService redis)
    {
        _redis = redis;
    }

    /// <inheritdoc />
    public int GenerateCode() => new Random().Next(100_000, 999_999);

    /// <inheritdoc />
    public async Task SavePendingRegistrationAsync(Guid id, PendingUserRegistration user, TimeSpan ttl)
    {
        var json = JsonSerializer.Serialize(user);
        await _redis.SetAsync($"{Prefix}{id}", json, ttl);
    }

    /// <inheritdoc />
    public async Task<PendingUserRegistration?> GetPendingRegistrationAsync(Guid id)
    {
        var json = await _redis.GetAsync($"{Prefix}{id}");
        return json is null ? null : JsonSerializer.Deserialize<PendingUserRegistration>(json);
    }

    /// <inheritdoc />
    public async Task<bool> VerifyCodeAsync(Guid id, int code)
    {
        var user = await GetPendingRegistrationAsync(id);
        return user is not null && user.VerificationCode == code.ToString();
    }

    /// <inheritdoc />
    public Task DeletePendingRegistrationAsync(Guid id)
    {
        return _redis.DeleteAsync($"{Prefix}{id}");
    }
}