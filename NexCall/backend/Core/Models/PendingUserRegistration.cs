namespace Core.Models;

/// <summary>
/// Модель для временного хранения данных о регистрации пользователя
/// </summary>
public class PendingUserRegistration
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = default!;
    
    /// <summary>
    /// Логин
    /// </summary>
    public string Username { get; set; } = default!;
    
    /// <summary>
    /// Отображаемое имя
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// Хэш пароля
    /// </summary>
    public string PasswordHash { get; set; } = default!;
    
    /// <summary>
    /// Код верификации
    /// </summary>
    public string VerificationCode { get; set; } = default!;
    
    /// <summary>
    /// Время истечения кода
    /// </summary>
    public DateTime ExpiresAt { get; set; } = default!;
}