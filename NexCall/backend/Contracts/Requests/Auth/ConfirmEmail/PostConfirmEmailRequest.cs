namespace Contracts.Requests.Auth.ConfirmEmail;

/// <summary>
/// Класс запроса на подтверждение почты
/// </summary>
public class PostConfirmEmailRequest
{
    /// <summary>
    /// Идентификатор записи в in-memory хранилище
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Код подтверждения
    /// </summary>
    public int Code { get; set; }
}