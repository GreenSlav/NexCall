namespace Core.Constants;

/// <summary>
/// Класс констант для JWT
/// </summary>
public static class Jwt
{
    /// <summary>
    /// Путь к секции настроек Jwt-токена в JSON файле конфигурации
    /// </summary>
    public const string PathToJwtConfigSection = "Jwt";
    
    /// <summary>
    /// Имя Jwt-токена в куках 
    /// </summary>
    public const string JwtTokenCookieName = "jwt_token";

    /// <summary>
    /// Название заголовка, в котором будет присылаться новый Jwt-токен, если он обновился
    /// </summary>
    public const string NewJwtTokenHeader = "X-New-Jwt-Token";
}