namespace AltStreamLib.Logging;

public class Logger
{
    public static Logger Singleton;

    public Logger() => Singleton = this;

    public event Action<LogMessage>? OnLog;

    public void Log(LogLevel logLevel, string message, Exception? error = null) =>
        OnLog?.Invoke(new LogMessage(logLevel, message, error));
}

public record LogMessage(
    LogLevel LogLevel,
    string Message,
    Exception? Error
);

public enum LogLevel
{
    Info,
    Warn,
    Error,
    Ping
}
