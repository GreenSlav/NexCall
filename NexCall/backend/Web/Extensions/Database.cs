using Core.Abstractions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Web.Extensions;

public static class Database
{
    public static void RegisterPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContext, EfContext>();
        services.AddDbContext<EfContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
    
    public static void RegisterRedisDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer
                .Connect(configuration.GetConnectionString("RedisConnection")
                         ?? throw new NullReferenceException("Строка подключения Redis не найдена")));
    }
}