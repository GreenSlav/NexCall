using Core.Abstractions;

namespace Core.Exceptions;

public class ValidationException : ApplicationBaseException
{
    public ValidationException(string logMessage, string clientMessage) : base(logMessage, clientMessage)
    {
    }
}