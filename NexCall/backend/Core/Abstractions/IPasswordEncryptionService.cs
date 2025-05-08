namespace Core.Abstractions;

/// <summary>
/// Интерфейс для сервиса шифрования паролей
/// </summary>
public interface IPasswordEncryptionService
{
    /// <summary>
    /// Метод шифрования пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    string EncryptPassword(string password);
    
    /// <summary>
    /// Метод валидации пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="encodedPassword">Зашифрованный пароль</param>
    /// <returns></returns>
    bool ValidatePassword(string password, string encodedPassword);
}