using Core.Abstractions;
using Infrastructure.Services;

namespace Web.Extensions;

/// <summary>
/// Класс регистрации сервисов Infrastructure слоя
/// </summary>
public static class InfrastructureServices
{
    /// <summary>
    /// Регистрация сервисов Infrastructure слоя
    /// </summary>
    /// <param name="services">Сервисы</param>
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IRedisService, RedisService>();
        services.AddScoped<IVerificationService, VerificationService>();
    }
}