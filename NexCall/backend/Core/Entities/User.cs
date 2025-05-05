namespace Core.Entities;

/// <summary>
/// Класс пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Username { get; set; } = default!;
    
    /// <summary>
    /// Почта пользователя
    /// </summary>
    public string Email { get; set; } = default!;
    
    /// <summary>
    /// Хэш пароля пользователя
    /// </summary>
    public string PasswordHash { get; set; } = default!;
    
    /// <summary>
    /// Отображаемое имя пользователя
    /// </summary>
    public string DisplayName { get; set; } = default!;
    
    /// <summary>
    /// Путь к аватарке пользователя в S3
    /// </summary>
    public string AvatarUrl { get; set; } = default!;
    
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public DateTime RegisteredAt { get; set; }
    
    /// <summary>
    /// Где пользователь числится участником
    /// </summary>
    public List<CallParticipant> CallParticipants { get; set; } = default!;
    
    // public List<Chat> Chats { get; set; } = default!;
    //
    // public List<Message> SentMessages { get; set; } = default!;

}