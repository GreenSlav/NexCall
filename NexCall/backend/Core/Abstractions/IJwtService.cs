using System.Security.Claims;
using Core.Entities;

namespace Core.Abstractions;

/// <summary>
/// Интерфейс сервиса работы с JWT токенами
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Метод генерации JWT-токена
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <returns></returns>
    string GenerateToken(User user);
    
    /// <summary>
    /// Метод получения Principal из токена
    /// </summary>
    /// <param name="token">Токен</param>
    /// <returns></returns>
    ClaimsPrincipal? GetPrincipalFromToken(string token);
}