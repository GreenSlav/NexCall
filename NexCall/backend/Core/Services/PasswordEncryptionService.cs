using System.Security.Cryptography;
using System.Text;
using Core.Abstractions;

namespace Core.Services;

public class PasswordEncryptionService : IPasswordEncryptionService
{
    public string EncryptPassword(string password)
    {
        password ??= string.Empty;

        var saltedValue = Encoding.UTF8.GetBytes(password);
        using var sha = SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(saltedValue));
    }
    
    public bool ValidatePassword(string password, string encodedPassword)
        => encodedPassword == EncryptPassword(password);
}