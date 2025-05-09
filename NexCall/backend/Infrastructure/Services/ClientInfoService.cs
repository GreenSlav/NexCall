using Core.Abstractions;

namespace Infrastructure.Services;

/// <summary>
/// Сервис определения устройства клиента
/// </summary>
public class ClientInfoService : IClientInfoService
{
    /// <inheritdoc />
    public bool IsMobileClient(string? userAgent, IDictionary<string, string?> headers)
    {
        if (string.IsNullOrWhiteSpace(userAgent))
            return false;

        userAgent = userAgent.ToLowerInvariant();

        return userAgent.Contains("android")
               || userAgent.Contains("iphone")
               || userAgent.Contains("ipad")
               || headers.TryGetValue("X-Mobile-App", out var platform) && platform?.ToLower() == "true";
    }

    /// <inheritdoc />
    public bool IsWebClient(string? userAgent, IDictionary<string, string?> headers)
    {
        if (string.IsNullOrWhiteSpace(userAgent))
            return false;

        userAgent = userAgent.ToLowerInvariant();

        return userAgent.Contains("mozilla")
               || userAgent.Contains("chrome")
               || userAgent.Contains("safari")
               || userAgent.Contains("firefox");
    }
}