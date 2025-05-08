namespace Contracts.Requests.Auth.Login;

/// <summary>
/// Запрос на вход
/// </summary>
public class PostLoginRequest
{
    /// <summary>
    /// Почта или логин
    /// </summary>
    public string EmailOrUsername { get; set; } = default!;
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}