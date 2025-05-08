using System.Security.Claims;

namespace Core.Abstractions;

/// <summary>
/// Интерфейс контекста текущего пользователя
/// </summary>
public interface IUserContext
{
    /// <summary>
    /// ИД текущего пользователя
    /// </summary>
    long CurrentUserId { get; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    string? Username { get; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    string? Email { get; }
    
    /// <summary>
    /// Отображаемое имя
    /// </summary>
    string? DisplayName { get; }
    
    /// <summary>
    /// Текущий пользователь
    /// </summary>
    ClaimsPrincipal? User { get; }
}