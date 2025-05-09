using System.Text;
using Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Web.Middlewares;

namespace Web.Extensions;

/// <summary>
/// Класс регистрации настроек аутентификации и авторизации
/// </summary>
public static class Auth
{
    /// <summary>
    /// Метод регистрации аутентификации и авторизации
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>()!;

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        
        services.AddAuthorization();
    }

    /// <summary>
    /// Метод использования аутентификации и авторизации
    /// </summary>
    /// <param name="app">Приложение</param>
    public static void UseAuth(this WebApplication app)
    {
        app.UseMiddleware<TokenExtractionMiddleware>();
        app.UseMiddleware<TokenRefreshMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}