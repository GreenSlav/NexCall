namespace Core.Abstractions;

/// <summary>
/// Интерфейс сервиса верификации
/// </summary>
public interface IVerificationService
{
    /// <summary>
    /// Верификация кода
    /// </summary>
    /// <param name="email">Адрес почты</param>
    /// <param name="code">Код подтверждения</param>
    /// <returns></returns>
    Task<bool> VerifyCodeAsync(string email, string code);

    /// <summary>
    /// Метод случайной генерации кода подтверждения
    /// </summary>
    /// <returns></returns>
    int GenerateCode();
}