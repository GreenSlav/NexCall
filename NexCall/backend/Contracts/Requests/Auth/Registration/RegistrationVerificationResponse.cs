namespace Contracts.Requests.Auth.Registration;

/// <summary>
/// Класс ответа на запрос подтверждения регистрации
/// </summary>
public class RegistrationVerificationResponse
{
    /// <summary>
    /// Идентификатор записи в in-memory хранилище
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Время истечения кода
    /// </summary>
    public DateTime ExpiresAt { get; set; }
}