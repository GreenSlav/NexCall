using Core.Options;

namespace Web.Extensions;

/// <summary>
/// Класс регистрации опций
/// </summary>
public static class Options
{
    /// <summary>
    /// Метод регистрации опций
    /// </summary>
    /// <param name="services">Сервисы</param>
    /// <param name="configuration">Конфигурация</param>
    public static void RegisterOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettingsOptions>(configuration.GetSection("EmailSettings"));
    }
}