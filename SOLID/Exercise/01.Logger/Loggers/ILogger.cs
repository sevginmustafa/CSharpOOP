using _01Logger.Appenders;

namespace _01Logger.Loggers
{
    public interface ILogger
    {
        public IAppender[] Appenders { get; }

        public void Info(string dateTime, string message);

        public void Warning(string dateTime, string message);

        public void Error(string dateTime, string message);

        public void Critical(string dateTime, string message);

        public void Fatal(string dateTime, string message);
    }
}
