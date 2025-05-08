namespace Core.Options;

/// <summary>
/// Класс для хранения настроек электронной почты
/// </summary>
public class EmailSettingsOptions
{
    /// <summary>
    /// С какого адрес отправляем
    /// </summary>
    public string FromAddress { get; set; } = default!;
    
    /// <summary>
    /// SMTP-сервер
    /// </summary>
    public string SmtpServer { get; set; } = default!;
    
    /// <summary>
    /// Порт
    /// </summary>
    public int Port { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; set; } = default!;
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
    
    /// <summary>
    /// Использовать ли SSL
    /// </summary>
    public bool UseSsl { get; set; }
}