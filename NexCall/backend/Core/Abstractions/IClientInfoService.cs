namespace Core.Abstractions;

/// <summary>
/// Интерфейс сервиса для определения устройства клиента
/// </summary>
public interface IClientInfoService
{
    /// <summary>
    /// Является ли клиент мобильным устройством
    /// </summary>
    /// <param name="userAgent">UserAgent</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    bool IsMobileClient(string? userAgent, IDictionary<string, string?> headers);

    /// <summary>
    /// Является ли клиент веб-браузером
    /// </summary>
    /// <param name="userAgent">UserAgent</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    bool IsWebClient(string? userAgent, IDictionary<string, string?> headers);
}