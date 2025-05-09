using Core.Constants;

namespace Web.Middlewares;

/// <summary>
/// Middleware для извлечения токенов из запроса в зависимости от платформы клиента
/// </summary>
public class TokenExtractionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="next">Следующий middleware</param>
    public TokenExtractionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Метод обработки запроса
    /// </summary>
    /// <param name="context">Контекст HTTP запроса</param>
    public async Task Invoke(HttpContext context)
    {
        string jwt = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last() ?? string.Empty;
        string? refreshToken;

        if (context.Request.Cookies.ContainsKey(RefreshToken.RefreshTokenCookieName))
        {
            // Web: берём refresh-токен из куки
            refreshToken = context.Request.Cookies[RefreshToken.RefreshTokenCookieName];
        }
        else if (context.Request.Headers.TryGetValue(RefreshToken.RefreshTokenHeaderName, out var value))
        {
            // Mobile: берём refresh-токен из заголовка
            refreshToken = value.FirstOrDefault();
        }
        else
        {
            refreshToken = null;
        }

        // Кладём в HttpContext.Items
        context.Items["jwt"] = jwt;
        context.Items["refreshToken"] = refreshToken;

        await _next(context);
    }
}