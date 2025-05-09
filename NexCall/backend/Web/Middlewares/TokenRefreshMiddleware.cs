using Core.Abstractions;
using Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Web.Middlewares;

/// <summary>
/// Middleware для обновления токена
/// </summary>
public class TokenRefreshMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="next">Следующий middleware</param>
    public TokenRefreshMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Метод обработки запроса
    /// </summary>
    /// <param name="context">Контекст HTTP запроса</param>
    /// <param name="refreshService">Сервис для работы с refresh-токеном</param>
    /// <param name="jwtService">Сервис для работы с JWT-токеном</param>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="jwtOptions">JWT-опции</param>
    public async Task Invoke(
        HttpContext context,
        IRefreshTokenService refreshService,
        IJwtService jwtService,
        IDbContext dbContext,
        IOptions<JwtOptions> jwtOptions)
    {
        await _next(context);

        // Если ответ был 401 — пробуем освежить токен
        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized
            && !context.Items.ContainsKey("TokenRefreshed"))
        {
            var refreshToken = context.Request.Cookies["refreshToken"];
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var userId = await refreshService.ValidateRefreshTokenAsync(refreshToken);
                if (userId is not null)
                {
                    var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId.Value);
                    if (user is not null)
                    {
                        var newAccessToken = jwtService.GenerateToken(user);

                        if (!context.Response.HasStarted)
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = StatusCodes.Status200OK;

                            context.Response.Headers["access-token"] = newAccessToken;

                            context.Items["TokenRefreshed"] = true;
                            // Заново прогоняем пайплайн с валидным токеном
                            await _next(context);
                        }
                    }
                }
            }
        }
    }
}