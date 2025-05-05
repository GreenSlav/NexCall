namespace Core.Entities;

/// <summary>
/// Класс запланированного звонка
/// </summary>
public class Call
{
    /// <summary>
    /// Идентификатор звонка
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Название мероприятия
    /// </summary>
    public string Title { get; set; } = default!;
    
    /// <summary>
    /// Дата и время запланированного начала мероприятия
    /// </summary>
    public DateTime ScheduledAt { get; set; }
    
    /// <summary>
    /// Начало звонка
    /// </summary>
    public DateTime? StartedAt { get; set; }
    
    /// <summary>
    /// Конец звонка
    /// </summary>
    public DateTime? EndedAt { get; set; }
    
    /// <summary>
    /// За сколько до начала звонка напомнить участникам о мероприятии
    /// </summary>
    public TimeSpan? NotifyBefore { get; set; }
    
    /// <summary>
    /// Идентификатор работы в Hangfire
    /// </summary>
    public string? HangfireJobId { get; set; }
    
    /// <summary>
    /// Кем был запланирован звонок
    /// </summary>
    public long CreatedByUserId { get; set; }
    
    /// <summary>
    /// Пользователь, который запланировал звонок
    /// </summary>
    public User CreatedByUser { get; set; } = default!;
    
    /// <summary>
    /// Групповой звонок или индивидуальный
    /// </summary>
    public bool IsGroupCall { get; set; }
    
    /// <summary>
    /// Список участников звонка
    /// </summary>
    public List<CallParticipant> Participants { get; set; } = new();
}