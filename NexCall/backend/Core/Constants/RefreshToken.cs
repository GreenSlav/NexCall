namespace Core.Constants;

/// <summary>
/// Класс констант refresh-токена
/// </summary>
public static class RefreshToken
{
    /// <summary>
    /// Путь к секции настроек Jwt-токена в JSON файле конфигурации
    /// </summary>
    public const string PathToRefreshTokenConfigSection = "RefreshToken";
    
    /// <summary>
    /// Название refresh-токена в куках
    /// </summary>
    public const string RefreshTokenCookieName = "refresh_token";

    /// <summary>
    /// Заголовок, содержащий refresh-токен (предусматривается для мобильных устройств)
    /// </summary>
    public const string RefreshTokenHeaderName = "X-Refresh-Token";
}