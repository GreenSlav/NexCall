namespace Contracts.Requests.Auth.Registration;

/// <summary>
/// Запрос на регистрацию
/// </summary>
public class PostRegistrationRequest
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
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}