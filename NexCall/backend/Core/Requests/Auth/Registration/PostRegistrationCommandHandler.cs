using System.Text.Json;
using Contracts.Requests.Auth.Registration;
using Core.Abstractions;
using Core.Exceptions;
using Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Core.Requests.Auth.Registration;

/// <summary>
/// Класс обработчика команды регистрации
/// </summary>
public class PostRegistrationCommandHandler : IRequestHandler<PostRegistrationCommand, RegistrationVerificationResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IEmailService _emailService;
    private readonly IVerificationService _verificationService;
    private readonly IPasswordEncryptionService _passwordHasher;
    private readonly IRedisService _redis;
    private readonly IValidationService _validationService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="emailService">Сервис работы с почтой</param>
    /// <param name="verificationService">Сервис верификации</param>
    /// <param name="passwordHasher">Сервис шифрования пароля</param>
    /// <param name="redis">Redis</param>
    /// <param name="validationService">Сервис валидации</param>
    public PostRegistrationCommandHandler(
        IDbContext dbContext,
        IEmailService emailService,
        IVerificationService verificationService,
        IPasswordEncryptionService passwordHasher,
        IRedisService redis,
        IValidationService validationService)
    {
        _dbContext = dbContext;
        _emailService = emailService;
        _verificationService = verificationService;
        _passwordHasher = passwordHasher;
        _redis = redis;
        _validationService = validationService;
    }
    
    public async Task<RegistrationVerificationResponse> Handle(PostRegistrationCommand request, CancellationToken cancellationToken)
    {
        ValidateInput(request);

        var emailExistsTask = _dbContext.Users.AnyAsync(u => u.Email == request.Email);
        var usernameExistsTask = _dbContext.Users.AnyAsync(u => u.Username == request.Username);

        await Task.WhenAll(emailExistsTask, usernameExistsTask);
        
        var emailExists = emailExistsTask.Result;
        var usernameExists = usernameExistsTask.Result;
        
        if (emailExists || usernameExists)
            throw new ApplicationBaseException(
                "Пользователь с такими данными уже существует",
                $"Пользователь с такими данными уже существует: {request.Username}, {request.Email}");

        var verificationCode = _verificationService.GenerateCode();
        var verificationGuid = Guid.NewGuid();
        var expiresAt = DateTime.UtcNow.AddMinutes(10);

        var hashedPassword = _passwordHasher.EncryptPassword(request.Password);

        var registrationPayload = new PendingUserRegistration
        {
            Email = request.Email,
            Username = request.Username,
            Name = request.Name,
            PasswordHash = hashedPassword,
            VerificationCode = verificationCode.ToString(),
            ExpiresAt = expiresAt
        };

        var json = JsonSerializer.Serialize(registrationPayload);
        await _redis.SetAsync($"register:{verificationGuid}", json, TimeSpan.FromMinutes(10));

        await _emailService.SendVerificationCodeAsync(request.Email, verificationCode);

        return new RegistrationVerificationResponse
        {
            Id = verificationGuid,
            ExpiresAt = expiresAt
        };
    }
    
    private void ValidateInput(PostRegistrationCommand request)
    {
        _validationService.ValidateEmail(request.Email);
        _validationService.ValidateUsername(request.Username);
        _validationService.ValidatePassword(request.Name);
    }
}