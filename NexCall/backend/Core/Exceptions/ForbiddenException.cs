using Core.Abstractions;

namespace Core.Exceptions;

public class ForbiddenException : ApplicationBaseException
{
    public ForbiddenException(string logMessage, string clientMessage) : base(logMessage, clientMessage)
    {
    }
}