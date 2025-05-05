using Core.Abstractions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

/// <summary>
/// EF Core контекст приложения
/// </summary>
public class EfContext : DbContext, IDbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Опции контекста</param>
    public EfContext(DbContextOptions<EfContext> options) : base(options) { }
    
    /// <inheritdoc />
    public DbSet<User> Users { get; set; }
    
    /// <inheritdoc />
    public DbSet<Call> Calls { get; set; }
    
    /// <inheritdoc />
    public DbSet<CallParticipant> CallParticipants { get; set; }
    
    /// <inheritdoc />
    //public DbSet<Chat> Chats { get; set; }
    
    /// <inheritdoc />
    //public DbSet<Message> Messages { get; set; }

    /// <summary>
    /// Метод настойки моделей
    /// </summary>
    /// <param name="modelBuilder">Билдер</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}