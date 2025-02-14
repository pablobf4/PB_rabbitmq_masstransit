namespace EventLoggingAPI.Events
{
    public interface ILogEvent
    {
        Guid LogId { get; }
        string Message { get; }
        string LogLevel { get; }
        DateTime Timestamp { get; }
    }
}
