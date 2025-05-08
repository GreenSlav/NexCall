using Core.Abstractions;

namespace Infrastructure.Services;

/// <summary>
/// Сервис верификации
/// </summary>
public class VerificationService : IVerificationService
{
    /// <inheritdoc />
    public Task<bool> VerifyCodeAsync(string email, string code)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public int GenerateCode() => new Random().Next(100_000, 999_999);
}