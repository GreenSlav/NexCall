using Contracts.Requests.Auth.ConfirmEmail;
using Contracts.Requests.Auth.Login;
using Contracts.Requests.Auth.Registration;
using Core.Abstractions;
using Core.Constants;
using Core.Requests.Auth.ConfirmEmail;
using Core.Requests.Auth.Login;
using Core.Requests.Auth.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

/// <summary>
/// Контроллер аутентификации и авторизации
/// </summary>
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор</param>
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Метод обработки логина пользователя
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] PostLoginRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new PostLoginCommand()
        {
            EmailOrUsername = request.EmailOrUsername,
            Password = request.Password
        }, cancellationToken);
        
        return Ok();
    }

    /// <summary>
    /// Метод обработки регистрации пользователя
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] PostRegistrationRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new PostRegistrationCommand()
        {
            Email = request.Email,
            Username = request.Username,
            Name = request.Name,
            Password = request.Password
        }, cancellationToken);
        
        return Ok(response);
    }

    /// <summary>
    /// Метод подтверждения почты
    /// </summary>
    /// <param name="clientInfoService">Сервис определения устройства клиента</param>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("confirm-mail")]
    public async Task<IActionResult> ConfirmEmail(
        [FromServices] IClientInfoService clientInfoService,
        [FromBody] PostConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        // TODO: Зарефакторить
        var response = await _mediator.Send(new PostConfirmEmailCommand()
        {
            Id = request.Id,
            Code = request.Code
        }, cancellationToken);

        var userAgent = Request.Headers.UserAgent.ToString();
        var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

        if (clientInfoService.IsWebClient(userAgent, headers))
        {
            Response.Cookies.Append(RefreshToken.RefreshTokenCookieName, response.RefreshToken!, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            return Ok(new { accessToken = response.AccessToken, refreshToken = (string?)null });
        }

        return Ok(response);
    }

    /// <summary>
    /// Метод верификации запроса
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("verify")]
    public async Task<IActionResult> Verify(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Метод разлогина пользователя
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("logout")]
    public IActionResult Logout(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}