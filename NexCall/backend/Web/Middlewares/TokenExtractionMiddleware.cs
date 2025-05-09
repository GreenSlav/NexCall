using Core.Constants;

namespace Web.Middlewares;

public class TokenExtractionMiddleware
{
    private readonly RequestDelegate _next;

    public TokenExtractionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

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