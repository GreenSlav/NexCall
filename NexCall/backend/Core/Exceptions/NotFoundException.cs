using Core.Abstractions;

namespace Core.Exceptions;

public class NotFoundException : ApplicationBaseException
{
    public NotFoundException(string logMessage, string clientMessage) : base(logMessage, clientMessage)
    {
    }
}