namespace Core.Options;

/// <summary>
/// Класс опций для refresh-токена
/// </summary>
public class RefreshTokenOptions
{
    /// <summary>
    /// Время жизни refresh-токена в днях
    /// </summary>
    public int LifetimeDays { get; set; } = 7;
}