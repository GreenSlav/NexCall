using System.IdentityModel.Tokens.Jwt;
using Core.Abstractions;
using Core.Constants;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;

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
    public async Task Invoke(
        HttpContext context,
        IRefreshTokenService refreshService,
        IJwtService jwtService,
        IDbContext dbContext)
    {
        var token = context.Items["jwt"] as string;
        var refreshToken = context.Items["refreshToken"] as string;

        if (!string.IsNullOrEmpty(token))
        {
            var principal = jwtService.GetPrincipalFromToken(token);

            if (principal is null || jwtService.IsTokenExpired(token))
            {
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var userId = await refreshService.ValidateRefreshTokenAsync(refreshToken);
                    if (userId.HasValue)
                    {
                        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId)
                                   ?? throw new NotFoundException(
                                       "Произошла ошибка",
                                       $"При попытке обновить токен пользователю ({userId}) он не был найден в БД");
                        var newJwt = jwtService.GenerateToken(user);
                        context.User = jwtService.GetPrincipalFromToken(newJwt)!;

                        context.Response.OnStarting(() =>
                        {
                            context.Response.Headers[Jwt.NewJwtTokenHeader] = newJwt;
                            return Task.CompletedTask;
                        });
                    }
                }
            }
            else
            {
                context.User = principal;
            }
        }

        await _next(context);
    }
}