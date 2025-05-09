using Core.Abstractions;
using Core.Entities;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnauthorizedAccessException = Core.Exceptions.UnauthorizedException;

namespace Core.Requests.Auth.Login;

/// <summary>
/// Обработчик команды <see cref="PostLoginCommand"/>
/// </summary>
public class PostLoginCommandHandler : IRequestHandler<PostLoginCommand>
{
    private readonly IDbContext _dbContext;
    private readonly IPasswordEncryptionService _passwordEncryptionService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="passwordEncryptionService">Сервис хэширования</param>
    public PostLoginCommandHandler(IDbContext dbContext, IPasswordEncryptionService passwordEncryptionService)
    {
        _dbContext = dbContext;
        _passwordEncryptionService = passwordEncryptionService;
    }

    /// <inheritdoc />
    public async Task Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        User? user;

        if (request.EmailOrUsername.Contains('@'))
            user = await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Email == request.EmailOrUsername, cancellationToken);
        else
            user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Username == request.EmailOrUsername, cancellationToken);

        if (user is null)
            throw new NotFoundException("Пользователь не найден",
                $"Пользователь ({request.EmailOrUsername}) не найден");

        if (_passwordEncryptionService.EncryptPassword(request.Password) != user.PasswordHash)
            throw new UnauthorizedAccessException("Неверный пароль",
                $"Пароль для пользователя ({request.EmailOrUsername}) неверен");

        // TODO: Тут токены устанавливать нужно
    }
}