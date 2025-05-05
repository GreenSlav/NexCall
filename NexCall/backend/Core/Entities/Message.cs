namespace Core.Entities;

/// <summary>
/// Класс сообщения
/// </summary>
[Obsolete("Не нужен, возможно, в будущем буду использовать как хранилище метаданных")]
public class Message
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    //public long Id { get; set; }
    
    /// <summary>
    /// Идентификатор отправителя
    /// </summary>
    //public long SenderId { get; set; }
    
    /// <summary>
    /// Отправитель сообщения
    /// </summary>
    //public User Sender { get; set; } = default!;
    
    /// <summary>
    /// Идентификатор чата
    /// </summary>
    //public long ChatId { get; set; }
    
    /// <summary>
    /// Чат, к которому относится сообщение
    /// </summary>
    //public Chat Chat { get; set; } = default!;
    
    /// <summary>
    /// Зашифрованный текст сообщения
    /// </summary>
    //public string EncryptedBody { get; set; } = default!;
    
    /// <summary>
    /// Дата и время отправки сообщения
    /// </summary>
    //public DateTime SentAt { get; set; }
}