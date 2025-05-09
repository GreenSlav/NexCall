using Core.Abstractions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Web.Extensions;

/// <summary>
/// Класс регистрации базы данных
/// </summary>
public static class Database
{
    /// <summary>
    /// Метод регистрации PostgreSQL
    /// </summary>
    /// <param name="services">Сервисы</param>
    /// <param name="configuration">Конфигурации</param>
    public static void RegisterPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContext, EfContext>();
        services.AddDbContext<EfContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
    
    /// <summary>
    /// Метод регистрации Redis
    /// </summary>
    /// <param name="services">Сервисы</param>
    /// <param name="configuration">Конфигурации</param>
    public static void RegisterRedisDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer
                .Connect(configuration.GetConnectionString("RedisConnection")
                         ?? throw new NullReferenceException("Строка подключения Redis не найдена")));
    }
}