using Contracts.Requests.Auth.ConfirmEmail;
using Core.Abstractions;
using Core.Entities;
using Core.Exceptions;
using MediatR;

namespace Core.Requests.Auth.ConfirmEmail;

/// <summary>
/// Обработчик для <see cref="PostConfirmEmailCommand"/> 
/// </summary>
public class PostConfirmEmailCommandHandler : IRequestHandler<PostConfirmEmailCommand, PostConfirmEmailResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IVerificationService _verificationService;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenService _refreshTokenService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="verificationService">Сервис верификации</param>
    /// <param name="jwtService">Сервис работы с Jwt</param>
    /// <param name="refreshTokenService">Сервис работы с refresh-токеном</param>
    public PostConfirmEmailCommandHandler(
        IDbContext dbContext,
        IVerificationService verificationService,
        IJwtService jwtService,
        IRefreshTokenService refreshTokenService)
    {
        _dbContext = dbContext;
        _verificationService = verificationService;
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService; 
    }

    /// <inheritdoc />
    public async Task<PostConfirmEmailResponse> Handle(PostConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var isValid = await _verificationService.VerifyCodeAsync(request.Id, request.Code);
        if (!isValid)
            throw new ApplicationBaseException("Неверный код подтверждения", "Неверный код или ID");

        var registration = await _verificationService.GetPendingRegistrationAsync(request.Id);
        if (registration is null)
            throw new ApplicationBaseException("Регистрация не найдена", "Возможно, код истёк");

        var user = new User
        {
            Email = registration.Email,
            Username = registration.Username,
            DisplayName = registration.Name,
            PasswordHash = registration.PasswordHash,
            RegisteredAt = DateTime.UtcNow
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _verificationService.DeletePendingRegistrationAsync(request.Id);
        
        var jwt = _jwtService.GenerateToken(user);
        var refreshToken = await _refreshTokenService.GenerateRefreshTokenAsync(user.Id);

        return new PostConfirmEmailResponse
        {
            AccessToken = jwt,
            RefreshToken = refreshToken,
        };
    }
}