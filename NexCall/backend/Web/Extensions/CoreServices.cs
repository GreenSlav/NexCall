using Core.Abstractions;
using Core.Services;
using Infrastructure.Services;
using Web.Authentication;

namespace Web.Extensions;

/// <summary>
/// Класс регистрации сервисов Core слоя
/// </summary>
public static class CoreServices
{
    /// <summary>
    /// Регистрация сервисов Core слоя
    /// </summary>
    /// <param name="services">Сервисы</param>
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Core.Entry).Assembly);
        });

        services.AddSingleton<IPasswordEncryptionService, PasswordEncryptionService>();
        services.AddScoped<IVerificationService, VerificationService>();
        services.AddSingleton<IValidationService, ValidationService>();
    }
}