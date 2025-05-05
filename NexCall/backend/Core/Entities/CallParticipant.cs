namespace Core.Entities;

/// <summary>
/// Участник звонка
/// </summary>
public class CallParticipant
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Идентификатор звонка
    /// </summary>
    public long CallId { get; set; }
    
    /// <summary>
    /// Звонок, к которому относится запись
    /// </summary>
    public Call Call { get; set; } = default!;
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public long UserId { get; set; }
    
    /// <summary>
    /// Пользователь, к которому относится запись
    /// </summary>
    public User User { get; set; } = default!;
    
    /// <summary>
    /// Является ли участник хостом
    /// </summary>
    public bool IsHost { get; set; }
    
    /// <summary>
    /// Во сколько присоединился участник
    /// </summary>
    public DateTime? JoinedAt { get; set; }
    
    /// <summary>
    /// Во сколько покинул участник
    /// </summary>
    public DateTime? LeftAt { get; set; }
}