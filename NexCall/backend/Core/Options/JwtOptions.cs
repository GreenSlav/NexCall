namespace Core.Options;

/// <summary>
/// Класс настроек JWT-токена
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// Издатель
    /// </summary>
    public string Issuer { get; set; } = default!;
    
    /// <summary>
    /// Аудитория
    /// </summary>
    public string Audience { get; set; } = default!;
    
    /// <summary>
    /// Секретный ключ
    /// </summary>
    public string SecretKey { get; set; } = default!;
    
    /// <summary>
    /// Время жизни токена в минутах
    /// </summary>
    public int AccessTokenLifetimeMinutes { get; set; }
}