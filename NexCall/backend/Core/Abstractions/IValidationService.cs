namespace Core.Abstractions;

/// <summary>
/// Интерфейс для валидации данных
/// </summary>
public interface IValidationService
{
    /// <summary>
    /// Метод валидации почты
    /// </summary>
    /// <param name="email">Почта</param>
    /// <returns></returns>
    bool ValidateEmail(string email);
    
    /// <summary>
    /// Метод валидации пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    bool ValidatePassword(string password);
    
    /// <summary>
    /// Метод валидации логина
    /// </summary>
    /// <param name="username">Логин</param>
    /// <returns></returns>
    bool ValidateUsername(string username);
}