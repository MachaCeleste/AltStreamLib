#if NET481
using System;
#endif
namespace AltStreamLib.Logging
{
    public class Logger
    {
        public static Logger Singleton;

        public Logger()
        {
            if (Singleton == null)
                Singleton = this;
        }

        public event Action<LogMessage>? OnLog;

        public void Log(LogLevel logLevel, string message, Exception? error = null) =>
            OnLog?.Invoke(new LogMessage(logLevel, message, error));
    }

#if NET481
public class LogMessage
{
    public LogLevel LogLevel { get; set; }
    public string Message { get; set; }
    public Exception Error { get; set; }

    public LogMessage(LogLevel logLevel, string message, Exception error)
    {
        this.LogLevel = logLevel;
        this.Message = message;
        this.Error = error;
    }

    public LogMessage() { }
}
#elif NET9_0_OR_GREATER
    public record LogMessage(
        LogLevel LogLevel,
        string Message,
        Exception? Error
    );
#endif

    public enum LogLevel
    {
        Info,
        Warn,
        Error,
        Ping
    }
}
