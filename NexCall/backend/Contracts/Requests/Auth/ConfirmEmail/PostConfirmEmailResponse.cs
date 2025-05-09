namespace Contracts.Requests.Auth.ConfirmEmail;

/// <summary>
/// Класс ответа на запрос на подтверждение почты
/// </summary>
public class PostConfirmEmailResponse
{
    /// <summary>
    /// Токен доступа
    /// </summary>
    public string AccessToken { get; set; } = default!;
    
    /// <summary>
    /// Refresh-токен
    /// </summary>
    public string RefreshToken { get; set; } = default!;
}