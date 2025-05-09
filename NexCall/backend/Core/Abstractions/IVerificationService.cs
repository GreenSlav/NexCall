using Core.Models;

namespace Core.Abstractions;

/// <summary>
/// Интерфейс сервиса верификации
/// </summary>
public interface IVerificationService
{
    /// <summary>
    /// Метод генерации кода верификации
    /// </summary>
    /// <returns></returns>
    int GenerateCode();
    
    /// <summary>
    /// Метод верификации кода подтверждения
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <param name="code">Код подтверждения</param>
    /// <returns></returns>
    Task<bool> VerifyCodeAsync(Guid id, int code);
    
    /// <summary>
    /// Метод сохранения временной записи подтверждения почты
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <param name="user">Пользователь, ожидающий подтверждения почты</param>
    /// <param name="ttl">Время жизни записи</param>
    /// <returns></returns>
    Task SavePendingRegistrationAsync(Guid id, PendingUserRegistration user, TimeSpan ttl);
    
    /// <summary>
    /// Метод получения временной записи подтверждения почты
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns></returns>
    Task<PendingUserRegistration?> GetPendingRegistrationAsync(Guid id);
    
    /// <summary>
    /// Метод удаления временной записи подтверждения почты
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns></returns>
    Task DeletePendingRegistrationAsync(Guid id);
}