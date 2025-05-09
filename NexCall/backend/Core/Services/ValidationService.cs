using System.Text.RegularExpressions;
using Core.Abstractions;
using ValidationException = Core.Exceptions.ValidationException;

namespace Core.Services;

/// <summary>
/// Сервис валидации данных
/// </summary>
public class ValidationService : IValidationService
{
    /// <inheritdoc />
    public bool ValidateEmail(string email)
    {
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ValidationException("Некорректный формат email", $"Некорректный формат email: {email}");
        
        return true;
    }

    /// <inheritdoc />
    public bool ValidatePassword(string password)
    {
        var onlyLatin = new Regex("^[a-zA-Z0-9]+$");
        
        if (!onlyLatin.IsMatch(password))
            throw new ValidationException(
                "Пароль должен содержать только латинские символы.",
                $"Некорректный пароль при регистрации: {password}");

        return true;
    }

    /// <inheritdoc />
    public bool ValidateUsername(string username)
    {
        var onlyLatin = new Regex("^[a-zA-Z0-9]+$");
        
        if (!onlyLatin.IsMatch(username) || username.Contains('@'))
            throw new ValidationException(
                "Логин должен содержать только латинские символы и не должен содержать '@'.",
                $"Некорректный логин при регистрации: {username}");

        return true;
    }
}