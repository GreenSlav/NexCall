using Core.Abstractions;

namespace Core.Exceptions;

public class UnauthorizedException : ApplicationBaseException
{
    public UnauthorizedException(string logMessage, string clientMessage) : base(logMessage, clientMessage)
    {
    }
}