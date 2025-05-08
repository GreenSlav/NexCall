namespace Core.Abstractions;

public interface IValidationService
{
    bool ValidateEmail(string email);
    
    bool ValidatePassword(string password);
    
    bool ValidateUsername(string username);
}