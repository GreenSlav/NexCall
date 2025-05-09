namespace Core.Abstractions;

/// <summary>
/// Интерфейс для сервиса отправки электронных писем
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Метод отправки кода для подтверждения аккаунта
    /// </summary>
    /// <param name="email">Адрес почты</param>
    /// <param name="code">Код верификации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task SendVerificationCodeAsync(string email, int code, CancellationToken cancellationToken);
}