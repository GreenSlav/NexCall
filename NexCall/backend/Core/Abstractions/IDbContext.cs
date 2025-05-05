using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Abstractions;

/// <summary>
/// Интерфейс EF-контекста для абстракции и удобства тестирования
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Пользователи
    /// </summary>
    DbSet<User> Users { get; }
    
    /// <summary>
    /// Запланированные созвоны
    /// </summary>
    DbSet<Call> Calls { get; }
    
    /// <summary>
    /// Участники созвонов
    /// </summary>
    DbSet<CallParticipant> CallParticipants { get; }

    /// <summary>
    /// Чаты
    /// </summary>
    //DbSet<Chat> Chats { get; }
    
    /// <summary>
    /// Сообщения в чатах
    /// </summary>
    //DbSet<Message> Messages { get; }

    /// <summary>
    /// Метод сохранения изменений в базе данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}