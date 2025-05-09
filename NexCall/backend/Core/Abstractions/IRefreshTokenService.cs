namespace Core.Abstractions;

/// <summary>
/// Интерфейс сервиса для работы с refresh-токеном
/// </summary>
public interface IRefreshTokenService
{
    /// <summary>
    /// Метод генерации refresh-токена
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns></returns>
    Task<string> GenerateRefreshTokenAsync(long userId);
    
    /// <summary>
    /// Метод валидации refresh-токена
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<long?> ValidateRefreshTokenAsync(string token);
    
    /// <summary>
    /// Метод преобразования refresh-токена в невалидный
    /// </summary>
    /// <param name="token">Токен</param>
    /// <returns></returns>
    Task InvalidateRefreshTokenAsync(string token);
}