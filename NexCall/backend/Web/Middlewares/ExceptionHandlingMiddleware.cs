using System.Net;
using System.Text.Json;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Middlewares;

/// <summary>
/// Класс middleware обработки исключений
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="next">Следующий middleware</param>
    /// <param name="logger">Логгер</param>
    public ExceptionHandlingMiddleware(RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Метод обработки запроса
    /// </summary>
    /// <param name="context">Контекст БД</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Логируем полный стектрейс
            _logger.LogError(ex, "Unhandled exception");

            // Если ответ уже начал писаться — просто пробрасываем
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("Response has already started, cannot write error response.");
                return;
            }

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Очистим всё, что могло начать писаться
        context.Response.Clear();
        context.Response.ContentType = "application/json";

        (int status, string title, string detail) = exception switch
        {
            // TODO: Переделать и добавить новые исключения и использовать ClientMessage
            NotFoundException nf => ((int)HttpStatusCode.NotFound, "Not Found", "Ресурс не был найден"),
            ForbiddenException fb => ((int)HttpStatusCode.Forbidden, "Access Denied", "Доступ к ресурсу ограничен"),
            ApplicationBaseException ax => ((int)HttpStatusCode.BadRequest, "Bad Request",
                "Нет возможности обработать запрос"),
            _ => ((int)HttpStatusCode.InternalServerError,
                "Internal Server Error",
                "Неожиданная ошибка, повторите запрос позднее")
        };

        context.Response.StatusCode = status;

        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

        var jsonOption = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(problem, jsonOption);
        await context.Response.WriteAsync(json);
    }
}