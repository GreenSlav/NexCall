namespace Core.Abstractions;

public abstract class ApplicationBaseException : Exception
{
    public string LogMessage { get; }
    public string ClientMessage { get; }

    protected ApplicationBaseException(string logMessage, string clientMessage)
        : base(logMessage)
    {
        LogMessage = logMessage;
        ClientMessage = clientMessage;
    }
}