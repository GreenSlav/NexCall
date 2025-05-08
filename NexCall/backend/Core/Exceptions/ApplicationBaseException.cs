namespace Core.Exceptions;

public class ApplicationBaseException : Exception
{
    public string LogMessage { get; }
    public string ClientMessage { get; }

    public ApplicationBaseException(string logMessage, string clientMessage)
        : base(logMessage)
    {
        LogMessage = logMessage;
        ClientMessage = clientMessage;
    }
}