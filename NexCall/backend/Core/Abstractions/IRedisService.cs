namespace Core.Abstractions;

/// <summary>
/// Интерфейс для сервиса работы с Redis
/// </summary>
public interface IRedisService
{
    /// <summary>
    /// Метод создания записи в Redis
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <param name="value">Значение</param>
    /// <param name="expiry">Срок истечения</param>
    /// <returns></returns>
    Task SetAsync(string key, string value, TimeSpan? expiry = null);
    
    /// <summary>
    /// Метод получения значения из Redis
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <returns></returns>
    Task<string?> GetAsync(string key);
}