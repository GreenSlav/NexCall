using Core.Abstractions;
using Core.Entities;
using Core.Exceptions;
using MediatR;

namespace Core.Requests.Auth.ConfirmEmail;

/// <summary>
/// Обработчик для <see cref="PostConfirmEmailCommand"/> 
/// </summary>
public class PostConfirmEmailCommandHandler : IRequestHandler<PostConfirmEmailCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IVerificationService _verificationService;

    public PostConfirmEmailCommandHandler(IDbContext dbContext, IVerificationService verificationService)
    {
        _dbContext = dbContext;
        _verificationService = verificationService;
    }

    /// <inheritdoc />
    public async Task Handle(PostConfirmEmailCommand request, CancellationToken cancellationToken)
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
    }
}