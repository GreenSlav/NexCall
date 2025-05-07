using Core.Abstractions;

namespace Core.Exceptions;

public class ConflictException : ApplicationBaseException
{
    public ConflictException(string logMessage, string clientMessage) : base(logMessage, clientMessage)
    {
    }
}